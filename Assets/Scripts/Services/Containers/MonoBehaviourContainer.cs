using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourContainer
{
    private readonly Dictionary<string, MonoBehaviour> keyService = new();
    public static MonoBehaviourContainer Instance = new();
    public T Get<T>() where T : MonoBehaviour
    {
        var key = typeof(T).ToString();
        if (keyService.TryGetValue(key, out MonoBehaviour value))
        {
            return value as T;
        }

        var monoBehaviour = GameObject.FindAnyObjectByType<T>();
        keyService.Add(key, monoBehaviour);
        return monoBehaviour;
    }
}