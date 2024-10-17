using System;
using System.Collections.Generic;

[Serializable]
public class GameData{
  public GameTime gameTime = new(1, 31, 9, 30);
  public CurrentScene currentScene = new();
  public List<SceneData> sceneDataList = new();
  public Inventory playerInventory = new(Settings.inventory.playerInitialInventoryCapacity);
  public Movement playerMovement =  new(new MovementDefinition(Settings.playerMovement.walkingSpeed, Settings.playerMovement.runnintSpeed));

  public SceneData GetSceneSaveModel(SceneInstance sceneInstance){
    var sceneSaveModel = sceneDataList.Find(s => s.sceneInstance == sceneInstance);
    if(sceneSaveModel == null){
      sceneSaveModel = new SceneData(sceneInstance);
      sceneDataList.Add(sceneSaveModel);
    }
    return sceneSaveModel;
  }
}
