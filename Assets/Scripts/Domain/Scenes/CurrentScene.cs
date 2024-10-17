using System;
[Serializable]
public class CurrentScene : Aggregate
{
    public SceneInstance instance;
    public event EventHandler<ChangeSceneEventArg> OnSceneChange;

    public CurrentScene() {}

    public CurrentScene(SceneInstance sceneInstance) {
        this.instance = sceneInstance;
    }

    public void ChangeScene(SceneSpawnPointDefinition newSceneSpawnPoint)
    {
        var eventArgs = new ChangeSceneEventArg()
        {
            newSceneSpawnPoint = newSceneSpawnPoint,
            currentScene = instance,
        };

        instance = newSceneSpawnPoint.sceneInstance;
        OnSceneChange?.Invoke(this, eventArgs);
    }

    public SceneInstance? GetCurrentScene(){
        return instance;
    }
}

public class ChangeSceneEventArg
{
    public SceneSpawnPointDefinition newSceneSpawnPoint;
    public SceneInstance? currentScene;
}