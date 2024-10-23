public class OnInventoryFull : DomainEvent<Inventory>
{
    public OnInventoryFull(Inventory value) : base(value)
    {
    }
}
public class OnInventoryUpdated : DomainEvent<Inventory>
{
    public OnInventoryUpdated(Inventory value) : base(value)
    {
    }
}


public class OnSelectedSlotChange : DomainEvent<Inventory>
{
    public InventorySlot selectedSlot; 
    public OnSelectedSlotChange(Inventory value, InventorySlot selectedSlot) : base(value)
    {
      this.selectedSlot = selectedSlot;
    }
}
