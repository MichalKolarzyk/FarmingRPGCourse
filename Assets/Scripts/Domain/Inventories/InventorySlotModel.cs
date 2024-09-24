public class InventorySlotModel
{
    public InventoryItemModel content = new();
    public bool IsSelected = false;

    public bool CanAdd(InventoryItemModel inventoryItemModel) => IsEmpty || content.itemDefinition == inventoryItemModel.itemDefinition;

    public bool TryAdd(InventoryItemModel inventoryItemModel)
    {
        if (!CanAdd(inventoryItemModel))
            return false;

        if (content.itemDefinition == inventoryItemModel.itemDefinition)
            content.quantity += inventoryItemModel.quantity;
        else
            content = inventoryItemModel;

        return true;
    }

    public void Clear(){
        IsSelected =false;
        content = new();
    }

    public bool CanRemove(InventoryItemModel inventoryItemModel) => !IsEmpty
        && content.itemDefinition == inventoryItemModel.itemDefinition
        && content.quantity >= inventoryItemModel.quantity;

    public bool TryRemove(InventoryItemModel inventoryItemModel)
    {
        if (!CanRemove(inventoryItemModel))
            return false;

        content.quantity -= inventoryItemModel.quantity;
        if (content.quantity == 0)
        {
            Clear();
        }
        return true;
    }

    public void Select(){
        if(IsEmpty){
            return;
        }
        IsSelected = true;
    }

    public void Unselect(){
        IsSelected = false;
    }

    public bool IsEmpty => content.itemDefinition == null && content.quantity == 0;
}
