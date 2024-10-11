using System;
using System.Collections.Generic;

public class ServiceContainer
{
    private readonly Dictionary<string, IService> keyService = new();
    public static ServiceContainer Instance = new();
    public T Get<T>() where T : class, IService
    {
        var key = typeof(T).ToString();
        if (keyService.TryGetValue(key, out IService value))
        {
            return value as T;
        }

        var service = Activator.CreateInstance<T>();
        keyService.Add(key, service);
        return service;
    }
}

public interface IService {}