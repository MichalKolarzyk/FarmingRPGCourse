using System;
using System.Collections.Generic;

public class InventoryModel
{
    public InventoryType inventoryType;
    public List<InventoryItemModel> items = new();
    public int Capacity;

    public DoaminEvent<InventoryModel> OnInventoryUpdated = new();
    public DoaminEvent<InventoryModel> OnInventoryFull = new();

    public InventoryModel(int capacity)
    {
        this.Capacity = capacity;
    }

    public InventoryModel() {}

    public bool TryAdd(InventoryItemModel newItem){
        if(!newItem.itemDefinition.canBePickedUp){
            return false;
        }
        
        var existingItem = items.Find(i => i.itemDefinition == newItem.itemDefinition);
        if(existingItem == null && items.Count < Capacity){
            items.Add(newItem);
            OnInventoryUpdated.Call(this);
            return true;
        }
        else if(existingItem != null){
            existingItem.quantity += newItem.quantity;
            OnInventoryUpdated.Call(this);
            return true;
        }
        else{
            OnInventoryFull.Call(this);
            return false;
        }
    }
}

public enum InventoryType{
    player,
    chest,
}