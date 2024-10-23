public class SceneDataContext : Context<SceneData>
{
    public override void Set(ref SceneData model)
    {
        this.model = model;
        FindAnyObjectByType<ItemCollectionContext>().Set(ref this.model.items);
    }
}