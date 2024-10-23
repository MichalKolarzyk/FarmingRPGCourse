public class OnMoveUpdate : DomainEvent<Movement>
{
  public OnMoveUpdate(Movement value) : base(value)
  {
  }
}

public class OnIsCarryingItemChangeEvent : DomainEvent<Movement>
{
  public OnIsCarryingItemChangeEvent(Movement value) : base(value)
  {
  }
}