using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDefinition", menuName = "ScriptableObjects/Item/ItemDefinition")]
public class ItemDefinition : ScriptableObject
{
    public int code;
    public ItemType itemType;
    public string description;
    public string longDescription;
    public Sprite sprite;
    public short useGridRadius;
    public float useRadius;
    public bool isStartingItem;
    public bool canBePickedUp;
    public bool canBeDropped;
    public bool canBeEaten;
    public bool canBeCarried;
}

public enum ItemType{
    Seed,
    Commodity,
    WateringTool,
    HoeingTool,
    ChoppingTool,
    BreakingTool,
    ReapingTool,
    CollectingTool,
    RepableScenary,
    Furniture,
    None,
    Count,
}