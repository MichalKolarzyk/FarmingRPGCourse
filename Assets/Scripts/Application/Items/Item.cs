using UnityEngine;

public class Item : ObjectMonoBehaviour<ItemModel>
{
    public ItemInfo itemInfo;
    private SpriteRenderer spriteRenderer;

    protected override ItemModel InitDefaultModel()
    {
        return new ItemModel(itemInfo.itemDefinition);
    }

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.sprite = itemInfo.itemDefinition.sprite;
    }

    public InventoryItemModel ToInventoryItemModel(){
        return new InventoryItemModel{
            itemDefinition = itemInfo.itemDefinition,
            quantity = 1,
        };
    }
}
