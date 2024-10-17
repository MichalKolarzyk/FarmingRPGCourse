using System;
public class Aggregate{
  public event Action<DomainEvent> OnDomainEvent;
  public void AddEvent<T>(T domainEvent) where T : DomainEvent{
    var key = typeof(T).ToString();
    OnDomainEvent?.Invoke(domainEvent);
  }
}