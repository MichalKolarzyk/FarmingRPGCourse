using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectService<T> : IService
    where T : ScriptableObject, IDefinition
{
    protected string assetFilter;
    private readonly List<T> values;
    public ScriptableObjectService()
    {
        if(string.IsNullOrEmpty(assetFilter))
            assetFilter = $"t:{typeof(T).Name}";

        values = LoadScriptableObjects();
    }

    public T GetValue(Predicate<T> predicate)
    {
        return values.Find(predicate);
    }

    public T GetById(string id){
        return values.Find(d => d.GetId() == id);
    }

    private List<T> LoadScriptableObjects()
    {
        string[] guids = AssetDatabase.FindAssets(assetFilter);
        List<T> scriptableObjects = new();
        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            T scriptableObject = AssetDatabase.LoadAssetAtPath<T>(path);
            scriptableObjects.Add(scriptableObject);
        }
        return scriptableObjects;
    }
}
