using System.Collections.Generic;
using UnityEngine;

public class ResourcesService : IService
{
  private readonly Dictionary<string, GameObject> keyService = new();

  public static ResourcesService Instance = new();

  public GameObject Get(GameObjectPrefab gameObjectPrefab)
  {
    var key = gameObjectPrefab.name;
    var containsKey = keyService.TryGetValue(key, out GameObject value);
    if (containsKey)
    {
      return value;
    }
    var gameObject = Resources.Load<GameObject>(key);
    keyService.Add(key, gameObject);
    return gameObject;
  }
}

  public class GameObjectPrefab
  {
    public readonly string name;
    private GameObjectPrefab(string name)
    {
      this.name = name;
    }

    public static GameObjectPrefab Item = new("Items/Item");
  }