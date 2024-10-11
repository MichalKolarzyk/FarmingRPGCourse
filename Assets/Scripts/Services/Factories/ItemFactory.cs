using UnityEngine;

public class ItemFactory : ServiceMonoBehaviour
{
  public GameObject prefab;

  public Item Create(Vector3 wordPosition, ItemInfo itemInfo)
  {
    var itemsParent = GameObjectContainer.Instance.Get(GameObjectTag.ItemParent);
    var itemGameObject = Instantiate(prefab, wordPosition, Quaternion.identity, itemsParent.transform);
    var item = itemGameObject.GetComponent<Item>();
    item.itemInfo = itemInfo;
    return item;
  }
}
