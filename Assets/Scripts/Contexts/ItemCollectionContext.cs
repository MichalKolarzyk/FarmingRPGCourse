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
        collection ??= children.Select(c => c.Model()).ToList();
        this.collection = collection;
        foreach (var child in children)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < collection.Count; i++)
        {
            var item = collection[i];
            itemFactory.Create(ref item, transform);
        }
    }

    public override void Add(Item item)
    {
        collection.Add(item);
        itemFactory.Create(ref item, transform);
    }

    public override void Remove(Context<Item> itemContext)
    {
        collection.Remove(itemContext.Model());
        Destroy(itemContext.gameObject);
    }
}
