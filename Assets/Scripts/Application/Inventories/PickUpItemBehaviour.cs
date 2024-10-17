using UnityEngine;

[RequireComponent(typeof(Context<Inventory>))]
public class PickUpItemBehaviour : MonoBehaviour
{
    private Context<Inventory> inventoryContext;
    private CollectionContext<Item> collectionItemContext;

    void Awake()
    {
        inventoryContext = GetComponent<Context<Inventory>>();
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        var inventory = inventoryContext.Get();
        collectionItemContext = FindObjectOfType<CollectionContext<Item>>();
        if (collider2D.TryGetComponent(out ItemContext itemContext))
        {
            var canAddToInventory = inventory.TryAdd(itemContext.ToInventoryItemModel());
            if(!canAddToInventory)
                return;
            
            collectionItemContext.Remove(itemContext);
            Destroy(itemContext.gameObject);
        }
    }
}
