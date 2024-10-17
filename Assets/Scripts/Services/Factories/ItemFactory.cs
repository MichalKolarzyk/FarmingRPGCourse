using UnityEngine;

public class ItemFactory : IService
{
  private GameObject prefab;
  private ScriptableObjectService<ItemInfo> scriptableObjectService;

  public ItemFactory()
  {
    prefab = ResourcesService.Instance.Get(GameObjectPrefab.Item);
    scriptableObjectService = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>();
  }

  public ItemContext Create(Item item, Transform parent)
  {
    var wordPosition = item.position.ToVector3();
    var itemGameObject = GameObject.Instantiate(prefab, wordPosition, Quaternion.identity, parent);
    var itemInfo = scriptableObjectService.GetValue(i => i.itemDefinition.description == item.itemDefinition.description);
    var itemContext = itemGameObject.GetComponent<ItemContext>();
    itemContext.Set(item);
    itemContext.itemInfo = itemInfo;
    return itemContext;
  }
}
