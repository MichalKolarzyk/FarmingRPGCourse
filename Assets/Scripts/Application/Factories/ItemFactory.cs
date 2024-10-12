using UnityEngine;

public class ItemFactory : MonoBehaviour
{
  private GameObject itemsParent;
  private GameObject prefab;
  void Awake(){
    itemsParent = GameObject.FindGameObjectWithTag(GameObjectTag.ItemParent.tag);
    prefab = ResourcesService.Instance.Get(GameObjectPrefab.Item);
  }

  public Item Create(Vector3 wordPosition, ItemInfo itemInfo)
  {
    var itemGameObject = Instantiate(prefab, wordPosition, Quaternion.identity, itemsParent.transform);
    var item = itemGameObject.GetComponent<Item>();
    item.itemInfo = itemInfo;
    return item;
  }
}
