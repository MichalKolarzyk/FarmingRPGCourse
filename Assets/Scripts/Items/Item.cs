using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemDefinition itemDefinition;
    private SpriteRenderer spriteRenderer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
