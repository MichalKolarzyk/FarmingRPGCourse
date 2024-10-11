using System.Collections.Generic;
using UnityEngine;

public class ServiceContainer
{
    private readonly Dictionary<string, object> keyService = new();

    public static ServiceContainer Instance = new();

    public T Get<T>() where T : ServiceMonoBehaviour{
        var key = typeof(T).ToString();
        if(keyService.TryGetValue(key, out object value)){
            return value as T;
        }
        var gameObject = Object.FindAnyObjectByType<T>();
        keyService.Add(key, gameObject);
        return gameObject;
    }

}
