using System;

[Serializable]
public class InventorySlot
{
    public InventoryItem content = new();
    public bool IsSelected = false;

    public bool CanAdd(InventoryItem inventoryItemModel) => IsEmpty || content.itemDefinition == inventoryItemModel.itemDefinition;

    public bool TryAdd(InventoryItem inventoryItemModel)
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

    public bool CanRemove(InventoryItem inventoryItemModel) => !IsEmpty
        && content.itemDefinition == inventoryItemModel.itemDefinition
        && content.quantity >= inventoryItemModel.quantity;

    public bool TryRemove(InventoryItem inventoryItemModel)
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

    public bool IsEmpty => content.itemDefinition == null || content.quantity == 0;
}
