
public class Inventory : ObjectMonoBehaviour<InventoryModel>
{
    protected override InventoryModel InitModelValue()
    {
        return new(Settings.inventory.playerInitialInventoryCapacity);
    }
}
