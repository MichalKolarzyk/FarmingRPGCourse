using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/Items/ItemInfo")]
public class ItemInfo : ScriptableObject
{
    public Sprite sprite;
    public ItemDefinition itemDefinition;
}
