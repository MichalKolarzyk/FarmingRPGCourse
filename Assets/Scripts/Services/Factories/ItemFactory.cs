using UnityEngine;

public class ItemFactory : IService
{
  private GameObject prefab;

  public ItemFactory()
  {
    prefab = ResourcesService.Instance.Get(GameObjectPrefab.Item);
  }

  public ItemContext Create(Item item, Transform parent)
  {
    var itemGameObject = Object.Instantiate(prefab, parent);
    var itemContext = itemGameObject.GetComponent<ItemContext>();
    itemContext.Set(item);
    return itemContext;
  }
}
