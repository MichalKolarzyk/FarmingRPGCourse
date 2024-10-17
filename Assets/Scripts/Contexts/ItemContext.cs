using UnityEngine;

public class ItemContext : Context<Item>
{
    public ItemInfo itemInfo;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Set(new Item(itemInfo.itemDefinition, Position.FromVector(transform.position)));
    }

    void Start()
    {
        spriteRenderer.sprite = itemInfo.sprite;
    }

    public InventoryItem ToInventoryItemModel(){
        return new InventoryItem{
            itemDefinition = itemInfo.itemDefinition,
            quantity = 1,
        };
    }
}
