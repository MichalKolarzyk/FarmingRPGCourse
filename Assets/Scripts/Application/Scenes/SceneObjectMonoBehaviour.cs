using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class SceneObjectMonoBehaviour : ObjectMonoBehaviour<SceneModel>
{

    public SceneInstance startScene = SceneInstance.Farm;
    public event Func<SceneModel, IEnumerator> OnBeforeSceneChange;
    public event Func<SceneModel, IEnumerator> OnAfterSceneChange;

    private SceneModel model;

    protected override SceneModel InitModelValue()
    {
        return new SceneModel();
    }

    void Start(){
        model.ChangeScene(startScene);
    }

    void OnEnable(){
        model = GetModel();
        model.OnSceneChange += OnChangeHandler;
    }

    void OnDisable(){
        model.OnSceneChange -= OnChangeHandler;
    }

    private void OnChangeHandler(object sender, ChangeSceneEventArg e)
    {
        var model = sender as SceneModel;
        StartCoroutine(OnChangeHandlerCoroutine(model, e));
    }

    IEnumerator OnChangeHandlerCoroutine(SceneModel model, ChangeSceneEventArg eventArgs){
        yield return OnBeforeSceneChange?.Invoke(model);

        if(eventArgs.oldScene != null){
            yield return SceneManager.UnloadSceneAsync((int)eventArgs.oldScene);
        }

        yield return SceneManager.LoadSceneAsync((int)eventArgs.newScene, LoadSceneMode.Additive);
        var newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        yield return OnAfterSceneChange?.Invoke(model);
    }
}
