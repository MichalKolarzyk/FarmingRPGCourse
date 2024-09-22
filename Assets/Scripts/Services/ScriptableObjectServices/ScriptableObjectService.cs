using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class ScriptableObjectService<T> : ServiceMonoBehaviour
    where T : ScriptableObject
{
    public string assetFilter;
    private List<T> values;
    private void Awake()
    {
        if(string.IsNullOrEmpty(assetFilter))
            assetFilter = $"t:{typeof(T).Name}";

        values = LoadScriptableObjects();
    }

    public List<T> GetValues()
    {
        return values;
    }

    public T GetValue(Predicate<T> predicate)
    {
        return values.Find(predicate);
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
