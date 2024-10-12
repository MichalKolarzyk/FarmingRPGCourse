using System;
using System.Numerics;
using UnityEngine.UIElements;

[Serializable]
public class SceneSpawnPointDefinition{
  public int positionX;
  public int positionY;
  public SceneInstance sceneInstance;
}

public enum SceneInstance{
    Farm = 1,
    Field = 2,
    Cabin = 3,
}