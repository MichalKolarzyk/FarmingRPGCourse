using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemCollectionContext : CollectionContext<Item>
{
    private ItemFactory itemFactory;
    private Grid grid;
    public void Awake()
    {
        itemFactory = ServiceContainer.Instance.Get<ItemFactory>();
        grid = FindObjectOfType<Grid>();
    }

    public override void Set(ref List<Item> collection)
    {
        var children = GetComponentsInChildren<ItemContext>();
        collection ??= children.Select(c => c.Get()).ToList();
        this.collection = collection;
        foreach (var child in children)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < collection.Count; i++)
        {
            var item = collection[i];
            itemFactory.Create(ref item, transform, grid);
        }
    }

    public override void Add(Item item)
    {
        collection.Add(item);
        itemFactory.Create(ref item, transform, grid);
    }

    public override void Remove(Context<Item> itemContext)
    {
        collection.Remove(itemContext.Get());
        Destroy(itemContext.gameObject);
    }
}
