using System;

public class CurrentSceneModel
{
    private SceneInstance? currentScene;
    public event EventHandler<ChangeSceneEventArg> OnSceneChange;

    public void ChangeScene(SceneSpawnPointDefinition newSceneSpawnPoint)
    {
        var eventArgs = new ChangeSceneEventArg()
        {
            newSceneSpawnPoint = newSceneSpawnPoint,
            currentScene = currentScene,
        };

        currentScene = newSceneSpawnPoint.sceneInstance;
        OnSceneChange?.Invoke(this, eventArgs);
    }

    public SceneInstance? GetCurrentScene(){
        return currentScene;
    }
}

public class ChangeSceneEventArg
{
    public SceneSpawnPointDefinition newSceneSpawnPoint;
    public SceneInstance? currentScene;
}