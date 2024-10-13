using System;

[Serializable]
public class ItemModel
{
    public ItemDefinition itemDefinition;
    public Position position;

    public ItemModel(ItemDefinition itemDefinition)
    {
        this.itemDefinition = itemDefinition;
    }
}
