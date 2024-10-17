using System;

[Serializable]
public class Item : Aggregate
{
    public ItemDefinition itemDefinition;
    public Position position;

    public Item(ItemDefinition itemDefinition, Position position)
    {
        this.itemDefinition = itemDefinition;
        this.position = position;
    }
}
