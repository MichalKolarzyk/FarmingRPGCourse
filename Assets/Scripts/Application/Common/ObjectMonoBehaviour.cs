using UnityEngine;

public abstract class ObjectMonoBehaviour<T> : MonoBehaviour
    where T : class
{
    private T model;

    protected abstract T InitModelValue();

    public T GetModel(){
        if(model != null)
            return model;

        model = InitModelValue();
        return model;
    }
}
