using UnityEngine;

[DefaultExecutionOrder(-100)]
public abstract class Context<T> : MonoBehaviour
{
    protected T model;

    public T Get()
    {
        return model;
    }
}
