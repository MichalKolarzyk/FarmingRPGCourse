using UnityEngine;

[DefaultExecutionOrder(-4000)]
public class ApplicationController : MonoBehaviour{

  public GameData gameData;

  private Repository repository;
  void Awake(){
    var container = ServiceContainer.Instance;
    container.Register<ISaveService, JsonSaveService>();
    container.Register<ScriptableObjectService<ItemInfo>>();
    container.Register<ItemFactory>();
    container.Register<MainCameraService>();
    container.Register<Repository>();
    container.Register<DraggableItemFactory>();
  }

  void Start(){
    repository = ServiceContainer.Instance.Get<Repository>();
    gameData = repository.Get();
    FindAnyObjectByType<GameDataContext>().Set(ref gameData);
  }

  void OnDisable(){
    repository.Save(gameData);
  }
}