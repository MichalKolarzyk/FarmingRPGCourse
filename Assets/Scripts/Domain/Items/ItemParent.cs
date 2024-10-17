using System;
using System.Collections.Generic;

[Serializable]
public class ItemParent : Aggregate
{
  public List<Item> itemModels = new();
  public event Action<Item> OnAddItem;
  public event Action<Item> OnRemoveItem;

  public void AddItem(Item item)
  {
    itemModels.Add(item);
    OnAddItem?.Invoke(item);
  }

  public void RemoveItem(Item item)
  {
    itemModels.Remove(item);
    OnRemoveItem?.Invoke(item);
  }
}