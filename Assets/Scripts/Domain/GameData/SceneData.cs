using System;
using System.Collections.Generic;

[Serializable]
public class SceneData : Entity{

  public SceneData(SceneInstance sceneInstance)
  {
    this.sceneInstance = sceneInstance;
  }

  public SceneData(){}
  public SceneInstance sceneInstance;
  public List<Item> items;
}