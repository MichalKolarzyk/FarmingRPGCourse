using System.Collections.Generic;
using UnityEngine;

public class GameObjectContainer : IService
{
  private readonly Dictionary<string, GameObject> keyService = new();

  public static GameObjectContainer Instance = new();

  public GameObject Get(GameObjectTag gameObjectTag)
  {
    var key = gameObjectTag.tag;
    var containsKey = keyService.TryGetValue(key, out GameObject value);
    if (containsKey && value != null)
    {
      return value;
    }
    if (containsKey && value == null)
    {
      keyService.Remove(key);
    }
    var gameObject = GameObject.FindGameObjectWithTag(key);
    keyService.Add(key, gameObject);
    return gameObject;
  }
}

public class GameObjectTag
{
  public readonly string tag;
  private GameObjectTag(string tag)
  {
    this.tag = tag;
  }

  public static GameObjectTag Player = new("Player");
  public static GameObjectTag ItemParent = new("ItemsParent");
}