public class OnSceneChange : DomainEvent
{
    public SceneInstance newScene;
    public SceneInstance previousScene;

    public OnSceneChange(SceneInstance previousScene, SceneInstance newScene)
    {
        this.previousScene = previousScene;
        this.newScene = newScene;
    }
}