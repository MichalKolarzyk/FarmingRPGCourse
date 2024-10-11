using UnityEngine;

public class ItemFactory : IService
{
  public Item Create(Vector3 wordPosition, ItemInfo itemInfo)
  {
    var prefab = PrefabContainer.Instance.Get(GameObjectPrefab.Item);
    var itemsParent = GameObjectContainer.Instance.Get(GameObjectTag.ItemParent);
    var itemGameObject = GameObject.Instantiate(prefab, wordPosition, Quaternion.identity, itemsParent.transform);
    var item = itemGameObject.GetComponent<Item>();
    item.itemInfo = itemInfo;
    return item;
  }
}
