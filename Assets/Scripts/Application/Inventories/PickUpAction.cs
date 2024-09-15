using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class PickUpAction : MonoBehaviour
{
    private Inventory inventory;

    void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Item item))
        {
            inventory.AddToInventory(item);
        }
    }
}
