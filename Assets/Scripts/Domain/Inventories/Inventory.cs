using System;
using System.Collections.Generic;

[Serializable]
public class Inventory : Aggregate
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
            AddEvent(new OnUpdate(this)); //OnInventoryUpdated?.Invoke(this);
            return true;
        }
        else
        {
            AddEvent(new OnFull(this)); // OnInventoryFull?.Invoke(this);
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
            AddEvent(new OnUpdate(this)); //OnInventoryUpdated?.Invoke(this);
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
        AddEvent(new OnUpdate(this)); //OnInventoryUpdated?.Invoke(this);
    }

    public void SetSeletedSlot(InventorySlot inventorySlotModel)
    {
        var selectedSlot = slots.Find(s => s.IsSelected);
        if (inventorySlotModel == selectedSlot)
            return;

        selectedSlot?.Unselect();
        inventorySlotModel?.Select();
        AddEvent(new OnSelectedSlotChange(this, selectedSlot)); //OnSelectedSlotChange?.Invoke(this, selectedSlot);
        AddEvent(new OnUpdate(this)); //OnInventoryUpdated?.Invoke(this);
    }

    public InventorySlot GetSelectedSlot()
    {
        return slots.Find(s => s.IsSelected);
    }


    public class OnUpdate : DomainEvent
    {
        public Inventory inventory;

        public OnUpdate(Inventory inventory)
        {
            this.inventory = inventory;
        }
    }
    public class OnFull : DomainEvent
    {
        public Inventory Inventory;

        public OnFull(Inventory inventory)
        {
            Inventory = inventory;
        }
    }
    public class OnSelectedSlotChange : DomainEvent
    {
        public InventorySlot inventorySlot;
        public Inventory inventory;

        public OnSelectedSlotChange(Inventory inventory, InventorySlot inventorySlot)
        {
            this.inventory = inventory;
            this.inventorySlot = inventorySlot;
        }
    }
}
