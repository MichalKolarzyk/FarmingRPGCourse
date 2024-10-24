public class MapContext : Context<Map>
{
    public override void Set(ref Map model)
    {
        model ??= new Map();
        this.model = model;
    }
}