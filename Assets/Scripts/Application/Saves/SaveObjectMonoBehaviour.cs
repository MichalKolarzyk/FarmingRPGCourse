public class SaveObjectMonoBehaviour : ObjectMonoBehaviour<SaveModel>
{
  private string filename = "TestSaveFile";
  protected override SaveModel InitDefaultModel()
  {
    var saveService = ServiceContainer.Instance.Get<SaveService>();
    if (!saveService.SaveExists(filename))
      return new SaveModel();

    return saveService.LoadGame<SaveModel>(filename);
  }


  void OnDisable()
  {
    var saveService = ServiceContainer.Instance.Get<SaveService>();
    var model = GetModel();
    saveService.SaveGame(filename, model);
  }
}