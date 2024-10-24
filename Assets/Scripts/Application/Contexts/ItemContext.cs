using UnityEngine;

public class ItemContext : Context<Item>
{
    public ItemInfo itemInfo;
    private SpriteRenderer spriteRenderer;
    private ScriptableObjectService<ItemInfo> itemInfoService;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        itemInfoService = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>();
        model ??= new Item(itemInfo.itemDefinition, Position.FromVector(transform.position));
    }

    public override void Set(ref Item model)
    {
        model ??= new Item(itemInfo.itemDefinition, Position.FromVector(transform.position));
        this.model = model;
        this.model.OnDomainEvent += eventBus.Publish;
        UpdateContext();
    }

    void OnDisable()
    {
        model.OnDomainEvent -= eventBus.Publish;
    }

    void Start()
    {
        UpdateContext();
    }

    protected override void UpdateContext()
    {
        var newItemInfo = itemInfoService.GetById(model.itemDefinition.GetId()) ?? itemInfo;
        itemInfo = newItemInfo;
        spriteRenderer.sprite = itemInfo.sprite;
        transform.position = model.position.ToVector3();
    }

    public InventoryItem ToInventoryItemModel()
    {
        return new InventoryItem
        {
            itemDefinition = itemInfo.itemDefinition,
            quantity = 1,
        };
    }
}
