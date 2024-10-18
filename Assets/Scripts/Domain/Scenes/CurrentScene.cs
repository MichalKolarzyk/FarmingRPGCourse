using System;
[Serializable]
public class CurrentScene
{
    public SceneInstance instance;
    public event EventHandler<ChangeSceneEventArg> OnSceneChange;
    public CurrentScene() {}

    public CurrentScene(SceneInstance sceneInstance) {
        this.instance = sceneInstance;
    }

    public void ChangeScene(SceneSpawnPointDefinition newSpawnPoint)
    {
        var eventArgs = new ChangeSceneEventArg()
        {
            newSpawnPoint = newSpawnPoint,
            currentScene = instance,
        };
        
        instance = newSpawnPoint.sceneInstance;
        OnSceneChange?.Invoke(this, eventArgs);
    }

    public SceneInstance? GetCurrentScene(){
        return instance;
    }
}

public class ChangeSceneEventArg
{
    public SceneSpawnPointDefinition newSpawnPoint;
    public SceneInstance? currentScene;
}