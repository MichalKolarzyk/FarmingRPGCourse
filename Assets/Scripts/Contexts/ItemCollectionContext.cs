using System.Linq;

public class ItemCollectionContext : CollectionContext<Item>
{
    private ItemFactory itemFactory;

    public void Awake()
    {
        var collectionElementContexts = GetComponentsInChildren<ItemContext>();
        itemFactory = ServiceContainer.Instance.Get<ItemFactory>();
        var repository = FindObjectOfType<Repository>();
        var sceneData = repository.GetCurrentSceneData();

        sceneData.items ??= collectionElementContexts.Select(i => i.Get()).ToList();
        collection = sceneData.items;
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
        UpdateContext();
    }

    protected override void UpdateContext()
    {
        var children = GetComponentsInChildren<ItemContext>();
        foreach (var child in children)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in collection)
        {
            itemFactory.Create(item, transform);
        }
    }
}
