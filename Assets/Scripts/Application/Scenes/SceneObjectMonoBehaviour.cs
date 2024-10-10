using System;
using System.Collections;

public class SceneObjectMonoBehaviour : ObjectMonoBehaviour<SceneModel>
{

    public event Func<SceneModel, IEnumerator> OnBeforeSceneChange;
    public event Func<SceneModel, IEnumerator> OnSceneChange;
    public event Func<SceneModel, IEnumerator> OnAfterSceneChange;

    private SceneModel model;

    protected override SceneModel InitModelValue()
    {
        return new SceneModel(SceneInstance.Farm);
    }

    void OnEnable(){
        var model = GetModel();

        model.OnChange += OnChangeHandler;
    }

    void OnDisable(){
        model.OnChange -= OnChangeHandler;
    }

    private void OnChangeHandler(object sender, SceneInstance e)
    {
        var model = sender as SceneModel;
        StartCoroutine(OnChangeHandlerCoroutine(model));
    }

    IEnumerator OnChangeHandlerCoroutine(SceneModel model){
        yield return OnBeforeSceneChange?.Invoke(model);
        yield return OnSceneChange?.Invoke(model);
        yield return OnAfterSceneChange?.Invoke(model);
    }
}
