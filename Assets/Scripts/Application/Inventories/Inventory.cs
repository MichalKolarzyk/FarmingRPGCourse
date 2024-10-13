
public class Inventory : ObjectMonoBehaviour<InventoryModel>
{
    protected override InventoryModel InitDefaultModel()
    {
        return new(Settings.inventory.playerInitialInventoryCapacity);
    }
}
