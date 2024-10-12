using System;
using System.Numerics;
using UnityEngine.UIElements;

[Serializable]
public class SceneSpawnPointDefinition{
  public float positionX;
  public float positionY;
  public SceneInstance sceneInstance;
}

public enum SceneInstance{
    Farm = 1,
    Field = 2,
    Cabin = 3,
}