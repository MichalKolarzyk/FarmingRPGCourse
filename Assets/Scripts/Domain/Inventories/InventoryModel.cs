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

    public bool TryRemoveItem(InventoryItemModel inventoryItemModel){
        if(!inventoryItemModel.itemDefinition.canBeDropped)
            return false;

        var existingItem = items.Find(i => i.itemDefinition == inventoryItemModel.itemDefinition);
        if(existingItem.quantity < inventoryItemModel.quantity){
            return false;
        }
        else if(existingItem.quantity == inventoryItemModel.quantity){
            items.Remove(existingItem);
            OnInventoryUpdated.Call(this);
            return true;
        }
        else{
            existingItem.quantity -= inventoryItemModel.quantity;
            OnInventoryUpdated.Call(this);
            return true;
        }
    }
}

public enum InventoryType{
    player,
    chest,
}