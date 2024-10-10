using System;

public class SceneModel
{
    private SceneInstance currentScene;
    public event EventHandler<SceneInstance> OnChange;

    public SceneModel(SceneInstance initialScene)
    {
        currentScene = initialScene;
    }

    public void ChangeScene(SceneInstance newScene){
        if(currentScene == newScene)
            return;

        currentScene = newScene;
        OnChange?.Invoke(this, newScene);
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