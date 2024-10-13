using System;
using System.Collections.Generic;

[Serializable]
public class SaveModel{
  public GameTimeModel gameTimeModel = new(1, 31, 9, 30);
  public List<SaveSceneModel> saveSceneModels = new();

  public SaveSceneModel GetSceneSaveModel(SceneInstance sceneInstance){
    var sceneSaveModel = saveSceneModels.Find(s => s.sceneInstance == sceneInstance);
    if(sceneSaveModel == null){
      sceneSaveModel = new SaveSceneModel(sceneInstance);
      saveSceneModels.Add(sceneSaveModel);
    }
    return sceneSaveModel;
  }
  
}
