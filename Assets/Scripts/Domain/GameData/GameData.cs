using System;
using System.Collections.Generic;

[Serializable]
public class GameData : Entity{
  public GameTime gameTime;
  public CurrentScene currentScene;
  public Inventory playerInventory;
  public Movement playerMovement;
  public Position playerPosition;
  public List<SceneData> sceneDataList = new();

  public SceneData GetSceneSaveModel(SceneInstance sceneInstance){
    var sceneSaveModel = sceneDataList.Find(s => s.sceneInstance == sceneInstance);
    if(sceneSaveModel == null){
      sceneSaveModel = new SceneData(sceneInstance);
      sceneDataList.Add(sceneSaveModel);
    }
    return sceneSaveModel;
  }
}
