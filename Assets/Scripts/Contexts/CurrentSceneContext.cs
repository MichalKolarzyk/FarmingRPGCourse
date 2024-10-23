using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneContext : Context<CurrentScene>
{
    public SceneSpawnPointInfo defaultSceneSpawnPointInfo;
    public event Func<OnSceneChange, IEnumerator> OnBeforeSceneChange;
    public event Func<OnSceneChange, IEnumerator> OnBeforeLoadNewScene;
    public event Func<OnSceneChange, IEnumerator> OnAfterLoadNewScene;
    public event Func<OnSceneChange, IEnumerator> OnAfterSceneChange;

    public override void Set(ref CurrentScene model)
    {
        model ??= new(defaultSceneSpawnPointInfo.definition);
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

        if (args.previousScene != SceneInstance.None)
        {
            yield return SceneManager.UnloadSceneAsync((int)args.previousScene);
        }

        yield return OnBeforeLoadNewScene?.Invoke(args);
        yield return SceneManager.LoadSceneAsync((int)args.newSpawnPoint.sceneInstance, LoadSceneMode.Additive);
        var newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        CreateGameData();
        yield return OnAfterLoadNewScene?.Invoke(args);


        yield return OnAfterSceneChange?.Invoke(args);
    }

    private void CreateGameData(){
        var sceneDataGameObject = new GameObject();
        var sceneDataContext = sceneDataGameObject.AddComponent<SceneDataContext>();
        var sceneData = Get().GetSceneData();
        sceneDataContext.Set(ref sceneData);
    }
}
