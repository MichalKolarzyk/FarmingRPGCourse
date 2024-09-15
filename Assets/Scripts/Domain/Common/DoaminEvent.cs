using System;

public class DoaminEvent<T>
{
    public delegate void DomainEventHandler(T sender);

    public event DomainEventHandler OnHandle;

    public void Call(T sender)
    {
        OnHandle?.Invoke(sender);
    }

    public void Subscribe(DomainEventHandler doaminEvent)
    {
        OnHandle += doaminEvent;
    }

    public void Unsubscribe(DomainEventHandler doaminEvent)
    {
        OnHandle -= doaminEvent;
    }
}
