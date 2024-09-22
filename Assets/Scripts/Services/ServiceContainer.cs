using System.Collections.Generic;
using UnityEngine;

public class ServiceContainer : MonoBehaviour
{
    private readonly Dictionary<string, object> keyService = new();

    public static ServiceContainer Instance;

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
