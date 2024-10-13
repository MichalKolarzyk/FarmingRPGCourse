using System;

[Serializable]
public class SaveSceneModel{

  public SaveSceneModel(SceneInstance sceneInstance)
  {
    this.sceneInstance = sceneInstance;
  }

  public SaveSceneModel(){}
  public SceneInstance sceneInstance;
  public ItemModelParent itemModelParent;
}