using System.Linq;

public class MapContext : Context<Map>
{
    public override void Set(ref Map model)
    {
        if(model == null){
            var gridProperties = GetComponentsInChildren<MapContextGridProperty>();
            model = new Map
            {
                canNotDig = gridProperties.FirstOrDefault(p => p.type == MapContextGridPropertyType.CanDig)?.GetMapProperty(),
                canNotDropItem = gridProperties.FirstOrDefault(p => p.type == MapContextGridPropertyType.CanDropItem)?.GetMapProperty()
            };
        }
        this.model = model;
    }
}