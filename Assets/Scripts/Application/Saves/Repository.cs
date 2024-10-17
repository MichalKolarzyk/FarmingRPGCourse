using UnityEngine;

[DefaultExecutionOrder(-110)]
public class Repository : MonoBehaviour
{
  public GameData Data;
  private string filename = "TestSaveFile";
  private SaveService saveService;

  void Awake()
  {
    saveService = ServiceContainer.Instance.Get<SaveService>();
    if (!saveService.SaveExists(filename))
    {
      Data = new GameData();
    }
    else
    {
      Data = saveService.LoadGame<GameData>(filename);
    }

  }


  void OnDisable()
  {
    saveService.SaveGame(filename, Data);
  }

  public SceneData GetCurrentSceneData()
  {
    return Data.GetSceneSaveModel(Data.currentScene.instance);
  }
}