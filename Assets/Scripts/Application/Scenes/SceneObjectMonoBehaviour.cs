public class SceneObjectMonoBehaviour : ObjectMonoBehaviour<SceneModel>
{
    protected override SceneModel InitModelValue()
    {
        return new SceneModel(SceneInstance.Farm);
    }
}
