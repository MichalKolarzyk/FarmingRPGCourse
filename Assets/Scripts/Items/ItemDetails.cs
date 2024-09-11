using UnityEngine;

//[CreateAssetMenu(fileName = "ItemDetails", menuName = "ScriptableObjects/Item/ItemDetails")]
[System.Serializable]
public class ItemDetails 
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