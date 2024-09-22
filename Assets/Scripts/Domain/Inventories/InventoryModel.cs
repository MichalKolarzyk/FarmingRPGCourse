using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryModel
{
    public List<InventorySlotModel> slots = new();
    public int Capacity;

    public DoaminEvent<InventoryModel> OnInventoryUpdated = new();
    public DoaminEvent<InventoryModel> OnInventoryFull = new();

    public InventoryModel(int capacity)
    {
        this.Capacity = capacity;
        for (int i = 0; i < Capacity; i++)
        {
            slots.Add(new InventorySlotModel());
        }
    }

    public InventoryModel() { }

    public bool TryAdd(InventoryItemModel newItem)
    {
        if (!newItem.itemDefinition.canBePickedUp)
        {
            return false;
        }

        var slot = GetSlot();
        if (slot != null)
        {
            slot.TryAdd(newItem);
            OnInventoryUpdated.Call(this);
            return true;
        }
        else
        {
            OnInventoryFull.Call(this);
            return false;
        }

        InventorySlotModel GetSlot(){
            var slot = slots.Find(s => s.content.itemDefinition == newItem.itemDefinition);
            if(slot != null)
                return slot;

            return slots.Find(s => s.IsEmpty);
        }
    }

    public bool TryRemove(InventoryItemModel inventoryItemModel)
    {
        if (!inventoryItemModel.itemDefinition.canBeDropped)
            return false;

        var slot = slots.Find(s => s.CanRemove(inventoryItemModel));
        if (slot != null)
        {
            slot.TryRemove(inventoryItemModel);
            OnInventoryUpdated.Call(this);
            return true;
        }
        return false;
    }

    public void SwapItems(InventorySlotModel slotA, InventorySlotModel slotB)
    {
        var slotAContent = slotA.content;
        var slotBContent = slotB.content;

        slotA.Clear();
        slotA.TryAdd(slotBContent);

        slotB.Clear();
        slotB.TryAdd(slotAContent);
        OnInventoryUpdated.Call(this);
    }
}
