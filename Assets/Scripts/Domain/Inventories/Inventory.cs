using System;
using System.Collections.Generic;
using Unity.VisualScripting;

[Serializable]
public class Inventory : Entity
{
    public List<InventorySlot> slots = new();
    public int Capacity;

    public Inventory(int capacity)
    {
        this.Capacity = capacity;
        for (int i = 0; i < Capacity; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    public Inventory() { }

    public void Start(){
        AddEvent(new OnInventoryUpdated(this));
        AddEvent(new OnSelectedSlotChange(this, null));
    }

    public bool TryAdd(InventoryItem newItem)
    {
        if (!newItem.itemDefinition.canBePickedUp)
        {
            return false;
        }

        var slot = GetSlot();
        if (slot != null)
        {
            slot.TryAdd(newItem);
            AddEvent(new OnInventoryUpdated(this));
            return true;
        }
        else
        {
            AddEvent(new OnInventoryFull(this));
            return false;
        }

        InventorySlot GetSlot()
        {
            var slot = slots.Find(s => s.content.itemDefinition?.GetId() == newItem.itemDefinition.GetId());
            if (slot != null)
                return slot;

            return slots.Find(s => s.IsEmpty);
        }
    }

    public bool TryRemove(InventoryItem inventoryItemModel)
    {
        if (!inventoryItemModel.itemDefinition.canBeDropped)
            return false;

        var slot = slots.Find(s => s.CanRemove(inventoryItemModel));
        if (slot != null)
        {
            slot.TryRemove(inventoryItemModel);
            AddEvent(new OnInventoryUpdated(this));
            return true;
        }
        return false;
    }

    public void SwapItems(InventorySlot slotA, InventorySlot slotB)
    {
        var slotAContent = slotA.content;
        var slotBContent = slotB.content;

        slotA.Clear();
        slotA.TryAdd(slotBContent);

        slotB.Clear();
        slotB.TryAdd(slotAContent);
        AddEvent(new OnInventoryUpdated(this));
    }

    public void SetSeletedSlot(InventorySlot newSlot)
    {
        var currentSlot = slots.Find(s => s.IsSelected);
        if (newSlot == currentSlot)
            return;

        currentSlot?.Unselect();
        newSlot?.Select();
        AddEvent(new OnSelectedSlotChange(this, currentSlot));
        AddEvent(new OnInventoryUpdated(this));
    }

    public InventorySlot GetSelectedSlot()
    {
        return slots.Find(s => s.IsSelected);
    }
}
