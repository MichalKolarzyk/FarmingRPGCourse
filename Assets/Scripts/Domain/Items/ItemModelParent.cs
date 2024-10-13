using System;
using System.Collections.Generic;

[Serializable]
public class ItemModelParent
{
  public List<ItemModel> itemModels = new();
  public event Action<ItemModel> OnAddItem;
  public event Action<ItemModel> OnRemoveItem;

  public void AddItem(ItemModel item)
  {
    itemModels.Add(item);
    OnAddItem?.Invoke(item);
  }

  public void RemoveItem(ItemModel item)
  {
    itemModels.Remove(item);
    OnRemoveItem?.Invoke(item);
  }
}