using System;
using UnityEngine;

public abstract class Context<T> : MonoBehaviour
    where T : Entity
{
    protected T model;
    protected EventBus eventBus = new();   
    
    protected virtual void UpdateContext(){
        return;
    }

    public abstract void Set(ref T model);

    void OnDisable()
    {
        model.OnDomainEvent -= eventBus.Publish;
    }

    public T Model()
    {
        return model;
    }

    public void Subscribe<TEvent>(Action<TEvent> action)
        where TEvent : class
    {
        eventBus.Subscribe(action);
    }

    public void Unsubscribe<TEvent>(Action<TEvent> action)
        where TEvent : class
    {
        eventBus.Remove(action);
    }
}
