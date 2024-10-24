
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectionContext<T> : MonoBehaviour
    where T : Entity
{
    protected List<T> collection;
    protected EventBus eventBus = new();
    public abstract void Set(ref List<T> collection);
    public abstract void Add(T item);
    public abstract void Remove(Context<T> item);

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