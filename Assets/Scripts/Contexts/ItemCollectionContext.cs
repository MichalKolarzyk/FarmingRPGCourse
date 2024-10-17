public class ItemCollectionContext : CollectionContext<Item>
{
    private ItemFactory itemFactory;

    public void Awake()
    {
        var repository = FindObjectOfType<Repository>();
        var sceneData = repository.GetCurrentSceneData();
        collection = sceneData.items;
        itemFactory = ServiceContainer.Instance.Get<ItemFactory>();
    }

    public override void Add(Item item)
    {
        collection.Add(item);
        itemFactory.Create(item, transform);
    }

    public override void Remove(Context<Item> itemContext)
    {
        collection.Remove(itemContext.Get());
        Destroy(itemContext.gameObject);
    }

    void Start()
    {
        var itemChildren = GetComponentsInChildren<ItemContext>();
        if (collection.Count == 0)
        {
            foreach (var item in itemChildren)
            {
                var itemModel = item.Get();
                collection.Add(itemModel);
            }
        }
        else
        {
            foreach (var child in itemChildren)
            {
                Destroy(child.gameObject);
            }
            foreach (var item in collection)
            {
                itemFactory.Create(item, transform);
            }
        }
    }
}
