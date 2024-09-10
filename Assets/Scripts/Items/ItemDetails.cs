using UnityEngine;

[System.Serializable]
public class ItemDetails : ScriptableObject
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
