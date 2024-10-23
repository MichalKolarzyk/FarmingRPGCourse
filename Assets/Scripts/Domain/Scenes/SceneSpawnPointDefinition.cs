using System;

[Serializable]
public class SceneSpawnPointDefinition{
  public float positionX;
  public float positionY;
  public SceneInstance sceneInstance;

  public Position GetPositoin(){
    return new Position(positionX, positionY);
  }
}

public enum SceneInstance{
    None = -1,
    Farm = 1,
    Field = 2,
    Cabin = 3,
}