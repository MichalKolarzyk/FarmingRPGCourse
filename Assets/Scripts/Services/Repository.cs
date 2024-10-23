
public class Repository : IService
{
  private ISaveService saveService;

  public GameData Get(string filename = "TestSaveFile")
  {
    saveService = ServiceContainer.Instance.Get<ISaveService>();
    GameData data;
    if (!saveService.Exists(filename))
    {
      data = new GameData();
    }
    else
    {
      data = saveService.Load<GameData>(filename);
    }
    return data;
  }


  public void Save(GameData data, string filename = "TestSaveFile"){
    saveService.Save(filename, data);
  }
}