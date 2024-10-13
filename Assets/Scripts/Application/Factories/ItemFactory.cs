using System;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
  private GameObject itemsParent;
  private GameObject prefab;
  private ScriptableObjectService<ItemInfo> scriptableObjectService;
  private ItemModelParent itemModelParent;

  void OnEnable()
  {
    itemModelParent = FindObjectOfType<ObjectMonoBehaviour<ItemModelParent>>().GetModel();
    itemModelParent.OnAddItem += OnAddItemHandler;
  }

  void OnDisable()
  {
    itemModelParent.OnAddItem -= OnAddItemHandler;
  }

  private void OnAddItemHandler(ItemModel model)
  {
    Create(model);
  }

  void Awake()
  {
    itemsParent = GameObject.FindGameObjectWithTag(GameObjectTag.ItemParent.tag);
    prefab = ResourcesService.Instance.Get(GameObjectPrefab.Item);
    scriptableObjectService = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>();
  }

  public Item Create(ItemModel itemModel)
  {
    var wordPosition = itemModel.position.ToVector3();
    var itemGameObject = Instantiate(prefab, wordPosition, Quaternion.identity, itemsParent.transform);
    var itemInfo = scriptableObjectService.GetValue(i => i.itemDefinition.description == itemModel.itemDefinition.description);
    var item = itemGameObject.GetComponent<Item>();
    item.itemInfo = itemInfo;
    item.SetModel(itemModel);
    return item;
  }
}
