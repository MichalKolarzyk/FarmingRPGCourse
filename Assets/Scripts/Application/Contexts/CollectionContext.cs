
using System.Collections.Generic;

public abstract class CollectionContext<T> : EventBus
  where T : Aggregate
{
    protected List<T> collection; 
    public abstract void Add(T item);
    public abstract void Remove(Context<T> item);
} 