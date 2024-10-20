using UnityEngine;

public class ItemContext : CollectionElementContext<Item>
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

    void Start()
    {
        UpdateContext();
    }

    protected override void UpdateContext()
    {
        var newItemInfo = itemInfoService.GetValue(d => d.itemDefinition.description == model.itemDefinition.description) ?? itemInfo;
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
