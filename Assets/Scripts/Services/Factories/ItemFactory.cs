using UnityEngine;

public class ItemFactory : IService
{
  private GameObject prefab;

  public ItemFactory()
  {
    prefab = ResourcesService.Instance.Get(GameObjectPrefab.Item);
  }

  public ItemContext Create(ref Item item, Transform parent, Grid grid)
  {
    var newPosition = grid.WorldToCell(item.position.ToVector3());
    item.position = Position.FromVector(newPosition);

    var itemGameObject = Object.Instantiate(prefab, newPosition, Quaternion.identity, parent);
    var itemContext = itemGameObject.GetComponent<ItemContext>();
    itemContext.Set(ref item);
    return itemContext;
  }
}
