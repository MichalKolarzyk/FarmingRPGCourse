using System;

public class Entity
{
  public void AddEvent<T>(T eventArgs)
    where T : DomainEvent
  {
    OnDomainEvent?.Invoke(eventArgs);
  }

  public event Action<DomainEvent> OnDomainEvent;
}


