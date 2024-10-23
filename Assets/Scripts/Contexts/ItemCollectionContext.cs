using System.Collections.Generic;
using System.Linq;

public class ItemCollectionContext : CollectionContext<Item>
{
    private ItemFactory itemFactory;
    public void Awake()
    {
        itemFactory = ServiceContainer.Instance.Get<ItemFactory>();
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
            var itemContext = itemFactory.Create(transform);
            var item = collection[i];
            itemContext.Set(ref item);
        }
    }

    public override void Add(Item item)
    {
        collection.Add(item);
        var itemContext = itemFactory.Create(transform);
        itemContext.Set(ref item);
    }

    public override void Remove(Context<Item> itemContext)
    {
        collection.Remove(itemContext.Get());
        Destroy(itemContext.gameObject);
    }
}
