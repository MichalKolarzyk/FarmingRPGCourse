using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemDefinition itemDefinition;
    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
