using System;
using UnityEngine;

public abstract class ObjectMonoBehaviour<T> : MonoBehaviour
    where T : class
{
    private T model;

    protected abstract T InitDefaultModel();

    public void SetModel(T model)
    {
        this.model = model;
    }

    public T GetModel()
    {
        if (model != null)
            return model;

        model = InitDefaultModel();
        return model;
    }
}
