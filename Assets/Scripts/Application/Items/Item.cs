using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    public ItemInfo itemInfo;
    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start(){
        spriteRenderer.sprite = itemInfo.itemDefinition.sprite;
    }
}
