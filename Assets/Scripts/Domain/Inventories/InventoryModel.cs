using System.Collections.Generic;

public class InventoryModel
{
    public InventoryType inventoryType;
    public List<InventoryItemModel> items = new();
    public int Capacity;

    public bool TryAdd(InventoryItemModel newItem){
        var existingItem = items.Find(i => i.itemDefinition == newItem.itemDefinition);
        if(existingItem == null && items.Count < Capacity){
            items.Add(newItem);
            return true;
        }
        else if(existingItem != null){
            existingItem.quantity += newItem.quantity;
            return true;
        }
        else{
            return false;
        }
    }

}

public enum InventoryType{
    player,
    chest,
}