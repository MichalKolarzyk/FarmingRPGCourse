using System;

[Serializable]
public class SceneSpawnPointDefinition
{
  public float positionX;
  public float positionY;
  public SceneInstance sceneInstance;

  public Position GetPositoin()
  {
    return new Position(positionX, positionY);
  }
}

public enum SceneInstance
{
  PersistentScene = 0,
  Scene1_Farm = 1,
  Scene2_Field = 2,
  Scene3_Cabin = 3,
}