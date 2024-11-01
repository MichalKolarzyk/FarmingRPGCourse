using UnityEngine;

public class DraggableItemFactory
{
  private readonly GameObject prefab;

  public DraggableItemFactory()
  {
    prefab = ResourcesService.Instance.Get(GameObjectPrefab.DraggableItem);
  }

  public DraggableItem Create(Transform parent)
  {
    return Object.Instantiate(prefab, parent).GetComponent<DraggableItem>();
  }
}