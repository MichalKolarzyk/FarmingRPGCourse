using UnityEngine;

public class ItemFactory : IService
{
  private GameObject prefab;

  public ItemFactory()
  {
    prefab = ResourcesService.Instance.Get(GameObjectPrefab.Item);
  }

  public ItemContext Create(Transform parent)
  {
    var itemGameObject = Object.Instantiate(prefab, parent);
    return itemGameObject.GetComponent<ItemContext>();
  }
}
