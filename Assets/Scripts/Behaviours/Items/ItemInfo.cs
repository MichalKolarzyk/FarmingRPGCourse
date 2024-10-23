using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/Items/ItemInfo")]
public class ItemInfo : ScriptableObject, IDefinition
{
    public Sprite sprite;
    public ItemDefinition itemDefinition;
    public string GetId() => itemDefinition.GetId();
    public bool IsEmpty() => itemDefinition.IsEmpty();
}
