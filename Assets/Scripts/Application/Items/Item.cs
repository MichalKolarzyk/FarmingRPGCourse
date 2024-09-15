using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemInfo itemInfo;
    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
