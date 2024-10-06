using System;

public class SceneModel
{
    private SceneInstance currentScene;
    public event EventHandler<SceneInstance> OnBeforeSceneChange;
    public event EventHandler<SceneInstance> OnAftereSceneChange;

    public SceneModel(SceneInstance initialScene)
    {
        currentScene = initialScene;
    }

    public void ChangeScene(SceneInstance newScene){
        if(currentScene == newScene)
            return;

        OnBeforeSceneChange?.Invoke(this, newScene);
        currentScene = newScene;
        OnAftereSceneChange?.Invoke(this, newScene);
    }

    public SceneInstance GetCurrentScene(){
        return currentScene;
    }
}

public enum SceneInstance{
    Farm,
    Field,
    Cabin,
}