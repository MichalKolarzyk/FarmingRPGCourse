public class OnSceneChange : DomainEvent
{
    public SceneSpawnPointDefinition newSpawnPoint;
    public SceneInstance previousScene;

    public OnSceneChange(SceneSpawnPointDefinition newSpawnPoint, SceneInstance previousScene)
    {
        this.newSpawnPoint = newSpawnPoint;
        this.previousScene = previousScene;
    }
}