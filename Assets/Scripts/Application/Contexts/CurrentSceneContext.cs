using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneContext : Context<CurrentScene>
{
    public SceneInstance sceneInstance;
    public event Func<OnSceneChange, IEnumerator> OnBeforeSceneChange;
    public event Func<OnSceneChange, IEnumerator> OnBeforeLoadNewScene;
    public event Func<OnSceneChange, IEnumerator> OnAfterLoadNewScene;
    public event Func<OnSceneChange, IEnumerator> OnAfterSceneChange;

    public override void Set(ref CurrentScene model)
    {
        model ??= new(sceneInstance);
        this.model = model;
        this.model.OnDomainEvent += eventBus.Publish;
        Subscribe<OnSceneChange>(OnChangeHandler);
        this.model.Start();
    }


    void OnDisable()
    {
        Unsubscribe<OnSceneChange>(OnChangeHandler);
    }

    private void OnChangeHandler(OnSceneChange args)
    {
        StartCoroutine(OnChangeHandlerCoroutine(args));
    }

    IEnumerator OnChangeHandlerCoroutine(OnSceneChange args)
    {
        yield return OnBeforeSceneChange?.Invoke(args);
        var previousScene = GetScene(args.previousScene);
        if(previousScene.isLoaded && args.previousScene != SceneInstance.PersistentScene){
            yield return SceneManager.UnloadSceneAsync((int)args.previousScene);
        }

        var newScene = GetScene(args.newScene);
        if(!newScene.isLoaded){
            yield return OnBeforeLoadNewScene?.Invoke(args);
            yield return SceneManager.LoadSceneAsync((int)args.newScene, LoadSceneMode.Additive);
            newScene = GetScene(args.newScene);
        }
        SceneManager.SetActiveScene(newScene);
        CreateGameData();
        yield return OnAfterLoadNewScene?.Invoke(args);
        yield return OnAfterSceneChange?.Invoke(args);
    }

    private Scene GetScene(SceneInstance sceneInstance){
        return SceneManager.GetSceneByBuildIndex((int)sceneInstance);
    }

    private void CreateGameData(){
        var sceneDataGameObject = new GameObject("SceneDataContext");
        var sceneDataContext = sceneDataGameObject.AddComponent<SceneDataContext>();
        var sceneData = Model().GetSceneData();
        sceneDataContext.Set(ref sceneData);
    }
}
