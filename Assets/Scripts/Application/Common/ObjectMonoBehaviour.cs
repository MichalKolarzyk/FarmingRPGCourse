using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMonoBehaviour<T> : MonoBehaviour
    where T : class
{
    public T model;
}
