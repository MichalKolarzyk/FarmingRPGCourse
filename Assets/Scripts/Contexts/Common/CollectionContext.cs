
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public abstract class CollectionContext<T> : MonoBehaviour
{
    protected List<T> collection; 
    public abstract void Add(T item);
    public abstract void Remove(Context<T> item);
} 