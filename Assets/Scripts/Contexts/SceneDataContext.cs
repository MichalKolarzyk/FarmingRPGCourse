public class SceneDataContext : Context<SceneData>
{
    public override void Set(ref SceneData model)
    {
        this.model = model;
        FindAnyObjectByType<MapContext>().Set(ref this.model.map);
        FindAnyObjectByType<ItemCollectionContext>().Set(ref this.model.items);
    }
}