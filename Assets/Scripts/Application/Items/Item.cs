using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemInfo itemDefinition;
    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
}
