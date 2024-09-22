using UnityEngine;

public class ItemFactory : ServiceMonoBehaviour
{
  public GameObject prefab;

  private GameObject itemsParent;

  void Awake()
  {
    itemsParent = GameObject.FindGameObjectWithTag(Settings.tags.ItemsParent);
  }

  public Item Create(Vector3 wordPosition, ItemInfo itemInfo)
  {
    var itemGameObject = Instantiate(prefab, wordPosition, Quaternion.identity, itemsParent.transform);
    var item = itemGameObject.GetComponent<Item>();
    item.itemInfo = itemInfo;
    return item;
  }
}
