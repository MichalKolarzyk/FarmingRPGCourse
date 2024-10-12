using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class SceneObjectMonoBehaviour : ObjectMonoBehaviour<SceneModel>
{

    public SceneSpawnPointInfo startScene;
    public event Func<ChangeSceneEventArg, IEnumerator> OnBeforeSceneChange;
    public event Func<ChangeSceneEventArg, IEnumerator> OnBeforeLoadNewScene;
    public event Func<ChangeSceneEventArg, IEnumerator> OnAfterLoadNewScene;
    public event Func<ChangeSceneEventArg, IEnumerator> OnAfterSceneChange;

    private SceneModel model;

    protected override SceneModel InitModelValue()
    {
        return new SceneModel();
    }

    void Start()
    {
        model.ChangeScene(startScene.definition);
    }

    void OnEnable()
    {
        model = GetModel();
        model.OnSceneChange += OnChangeHandler;
    }

    void OnDisable()
    {
        model.OnSceneChange -= OnChangeHandler;
    }

    private void OnChangeHandler(object sender, ChangeSceneEventArg e)
    {
        var model = sender as SceneModel;
        StartCoroutine(OnChangeHandlerCoroutine(model, e));
    }

    IEnumerator OnChangeHandlerCoroutine(SceneModel model, ChangeSceneEventArg eventArgs)
    {
        yield return OnBeforeSceneChange?.Invoke(eventArgs);

        if (eventArgs.currentScene != null)
        {
            yield return SceneManager.UnloadSceneAsync((int)eventArgs.currentScene);
        }

        yield return OnBeforeLoadNewScene?.Invoke(eventArgs);
        yield return SceneManager.LoadSceneAsync((int)eventArgs.newSceneSpawnPoint.sceneInstance, LoadSceneMode.Additive);
        var newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        yield return OnAfterLoadNewScene?.Invoke(eventArgs);


        yield return OnAfterSceneChange?.Invoke(eventArgs);
    }
}
