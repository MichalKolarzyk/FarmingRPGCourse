using System;

public class SceneModel
{
    private SceneInstance? currentScene;
    public event EventHandler<ChangeSceneEventArg> OnSceneChange;

    public void ChangeScene(SceneInstance newScene){
        if(currentScene == newScene)
            return;
        
        var eventArgs = new ChangeSceneEventArg(){
            newScene = newScene,
            oldScene = currentScene,
        };

        currentScene = newScene;
        OnSceneChange?.Invoke(this, eventArgs);
    }
}

public class ChangeSceneEventArg{
    public SceneInstance newScene;
    public SceneInstance? oldScene;
}

public enum SceneInstance{
    Farm = 1,
    Field = 2,
    Cabin = 3,
}