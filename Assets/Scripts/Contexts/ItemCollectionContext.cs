using System.Linq;

public class ItemCollectionContext : CollectionContext<Item>
{
    private ItemFactory itemFactory;

    public void Awake()
    {
        var itemFactory = ServiceContainer.Instance.Get<ItemFactory>();
        var repository = FindObjectOfType<Repository>();
        var sceneData = repository.GetCurrentSceneData();
        // if (sceneData.items == null)
        // {
        //     var itemChildren = GetComponentsInChildren<ItemContext>();
        //     sceneData.items = itemChildren.Select(i => i.Get()).ToList();
        // }
        // collection = sceneData.items;
        // itemFactory = ServiceContainer.Instance.Get<ItemFactory>();

        var collectionElementContexts = GetComponentsInChildren<ItemContext>();
        if (sceneData.items == null)
        {
            sceneData.items = collectionElementContexts.Select(i => i.Get()).ToList();
            collection = sceneData.items;
        }
        else{
            collection = sceneData.items;
            for(int i = 0; i < collection.Count; i++){
                var item = collection[i];
                var itemContext = collectionElementContexts[i] ?? itemFactory.Create(item, transform);
                itemContext.Set(item);
            }
        }


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

        foreach (var child in itemChildren)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in collection)
        {
            itemFactory.Create(item, transform);
        }
    }

    protected override CollectionElementContext<Item>[] Get()
    {
        return GetComponentsInChildren<ItemContext>();
    }

    protected override CollectionElementContext<Item> Create(Item model)
    {
        return ServiceContainer.Instance.Get<ItemFactory>().Create(model, transform);
    }
}
