using System;
using System.Collections.Generic;

[Serializable]
public class Inventory
{
    public List<InventorySlot> slots = new();
    public int Capacity;

    public event Action<Inventory> OnInventoryFull;
    public event Action<Inventory> OnInventoryUpdated;
    public event Action<Inventory, InventorySlot> OnSelectedSlotChange;

    public Inventory(int capacity)
    {
        this.Capacity = capacity;
        for (int i = 0; i < Capacity; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    public Inventory() { }

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
            OnInventoryUpdated?.Invoke(this);
            return true;
        }
        else
        {
            OnInventoryFull?.Invoke(this);
            return false;
        }

        InventorySlot GetSlot()
        {
            var slot = slots.Find(s => s.content.itemDefinition == newItem.itemDefinition);
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
            OnInventoryUpdated?.Invoke(this);
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
        OnInventoryUpdated?.Invoke(this);
    }

    public void SetSeletedSlot(InventorySlot newSlot)
    {
        var currentSlot = slots.Find(s => s.IsSelected);
        if (newSlot == currentSlot)
            return;

        currentSlot?.Unselect();
        newSlot?.Select();
        OnSelectedSlotChange?.Invoke(this, currentSlot);
        OnInventoryUpdated?.Invoke(this);
    }

    public InventorySlot GetSelectedSlot()
    {
        return slots.Find(s => s.IsSelected);
    }
}
