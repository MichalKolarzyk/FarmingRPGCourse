using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class CurrentSceneContext : Context<CurrentScene>
{
    public event Func<ChangeSceneEventArg, IEnumerator> OnBeforeSceneChange;
    public event Func<ChangeSceneEventArg, IEnumerator> OnBeforeLoadNewScene;
    public event Func<ChangeSceneEventArg, IEnumerator> OnAfterLoadNewScene;
    public event Func<ChangeSceneEventArg, IEnumerator> OnAfterSceneChange;

    void OnEnable()
    {
        var repository = FindObjectOfType<Repository>();
        repository.Data.currentScene ??= new(SceneInstance.Farm);
        model = repository.Data.currentScene;
        model.OnSceneChange += OnChangeHandler;
    }

    void Start()
    {
        if (model.instance == 0)
            model.instance = SceneInstance.Farm;

        StartCoroutine(SetScene(model.instance));
    }


    void OnDisable()
    {
        model.OnSceneChange -= OnChangeHandler;
    }

    private void OnChangeHandler(object sender, ChangeSceneEventArg e)
    {
        var model = sender as CurrentScene;
        StartCoroutine(OnChangeHandlerCoroutine(model, e));
    }

    IEnumerator SetScene(SceneInstance instance)
    {
        yield return SceneManager.LoadSceneAsync((int)instance, LoadSceneMode.Additive);
        var newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
    }

    IEnumerator OnChangeHandlerCoroutine(CurrentScene model, ChangeSceneEventArg eventArgs)
    {
        yield return OnBeforeSceneChange?.Invoke(eventArgs);

        if (eventArgs.currentScene != null)
        {
            yield return SceneManager.UnloadSceneAsync((int)eventArgs.currentScene);
        }

        yield return OnBeforeLoadNewScene?.Invoke(eventArgs);
        yield return SceneManager.LoadSceneAsync((int)eventArgs.newSpawnPoint.sceneInstance, LoadSceneMode.Additive);
        var newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        yield return OnAfterLoadNewScene?.Invoke(eventArgs);


        yield return OnAfterSceneChange?.Invoke(eventArgs);
    }
}
