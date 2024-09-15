using System;

public delegate void DomainEventHandler<T>(T sender);
public class DoaminEvent<T>
{
    public event DomainEventHandler<T> OnHandle;

    public void Call(T sender)
    {
        OnHandle?.Invoke(sender);
    }

    public void Subscribe(DomainEventHandler<T> doaminEvent)
    {
        OnHandle += doaminEvent;
    }

    public void Unsubscribe(DomainEventHandler<T> doaminEvent)
    {
        OnHandle -= doaminEvent;
    }
}
