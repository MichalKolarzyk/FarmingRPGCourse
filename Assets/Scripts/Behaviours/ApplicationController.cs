using UnityEngine;

[DefaultExecutionOrder(-4000)]
public class ApplicationController : MonoBehaviour{
  void Awake(){
    var container = ServiceContainer.Instance;
    container.Register<ISaveService, JsonSaveService>();
    container.Register<ScriptableObjectService<ItemInfo>>();
    container.Register<ItemFactory>();
    container.Register<MainCameraService>();
  }
}