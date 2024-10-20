using UnityEngine;

[DefaultExecutionOrder(-110)]
public class Repository : MonoBehaviour
{
  public GameData Data;
  private string filename = "TestSaveFile";
  private ISaveService saveService;

  void Awake()
  {
    saveService = ServiceContainer.Instance.Get<ISaveService>();
    if (!saveService.Exists(filename))
    {
      Data = new GameData();
    }
    else
    {
      Data = saveService.Load<GameData>(filename);
    }

  }


  void OnDisable()
  {
    saveService.Save(filename, Data);
  }

  public SceneData GetCurrentSceneData()
  {
    return Data.GetSceneSaveModel(Data.currentScene.instance);
  }
}