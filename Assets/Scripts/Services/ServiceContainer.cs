using System;
using System.Collections.Generic;

public class ServiceContainer
{
    private readonly Dictionary<Type, Type> keyInterfaceImplementation = new();
    private readonly Dictionary<Type, object> keyInterfaceService = new();
    public static ServiceContainer Instance = new();

    public void Register<TInterface, TImplementation>(){
        keyInterfaceImplementation.Add(typeof(TInterface), typeof(TImplementation));
    }

    public void Register<TImplementation>(){
        keyInterfaceImplementation.Add(typeof(TImplementation), typeof(TImplementation));
    }

    public TInterface Get<TInterface>(){

        if(keyInterfaceService.TryGetValue(typeof(TInterface), out var existingService)){
            return (TInterface)existingService; 
        }

        var implementation = keyInterfaceImplementation[typeof(TInterface)];
        var newService = (TInterface)Activator.CreateInstance(implementation);
        keyInterfaceService.Add(typeof(TInterface), newService);
        return newService;
    }
}

public interface IService {}