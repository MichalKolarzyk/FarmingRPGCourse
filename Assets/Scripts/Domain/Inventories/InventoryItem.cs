using System;

[Serializable]
public class InventoryItem
{
    public ItemDefinition itemDefinition = null;
    public int quantity = 0;

    public static InventoryItem One(ItemDefinition itemDefinition) => new()
    {
        itemDefinition = itemDefinition,
        quantity = 1,
    };
}
