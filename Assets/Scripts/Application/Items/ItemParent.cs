using System.Linq;

public class ItemParent : ObjectMonoBehaviour<ItemModelParent>
{
    protected override ItemModelParent InitDefaultModel()
    {
        var saveModel = FindObjectOfType<SaveObjectMonoBehaviour>().GetModel();
        var sceneModel = FindObjectOfType<Scene>().GetModel();
        var currentSceneInstance = sceneModel.GetCurrentScene();
        var currentSceneSave = saveModel.GetSceneSaveModel(currentSceneInstance ?? SceneInstance.Farm);
        currentSceneSave.itemModelParent ??= new ItemModelParent();
        return currentSceneSave.itemModelParent;
    }

    void Start(){
        var itemChildren = GetComponentsInChildren<Item>();
        var model = GetModel();
        if(model.itemModels.Count == 0){
            foreach(var item in itemChildren){
                var itemModel = item.GetModel();
                itemModel.position = Position.FromVector(item.transform.position);
                model.AddItem(itemModel);
            }
        }
        else{
            foreach(var child in itemChildren){
                Destroy(child);
            }
            var items = model.itemModels.ToList();
            model.itemModels.RemoveAll(i => true);
            foreach(var item in items){
                model.AddItem(item);
            }
        }
    }
}
