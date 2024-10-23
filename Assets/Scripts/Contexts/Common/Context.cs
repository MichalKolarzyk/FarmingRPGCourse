using System;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public abstract class Context<T> : MonoBehaviour
    where T : Entity
{
    protected T model;
    protected EventBus eventBus = new();   
    
    protected virtual void UpdateContext(){
        return;
    }

    public abstract void Set(ref T model);
    // {
    //     var previousModel = model;
    //     if (previousModel != null) previousModel.OnDomainEvent -= eventBus.Publish;
    //     this.model = model;
    //     model.OnDomainEvent += eventBus.Publish;

    //     UpdateContext();
    // }

    void OnDisable()
    {
        model.OnDomainEvent -= eventBus.Publish;
    }

    public T Get()
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
