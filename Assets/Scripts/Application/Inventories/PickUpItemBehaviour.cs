using System;
using UnityEngine;

[RequireComponent(typeof(Context<Inventory>))]
public class PickUpItemBehaviour : MonoBehaviour
{
    private Context<Inventory> inventoryContext;
    private Lazy<CollectionContext<Item>> collectionItemContextLazy;

    void Awake()
    {
        inventoryContext = GetComponent<Context<Inventory>>();
        collectionItemContextLazy = new Lazy<CollectionContext<Item>>(() => FindObjectOfType<CollectionContext<Item>>());
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        var inventory = inventoryContext.Get();
        var collectionItemContext = collectionItemContextLazy.Value;

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
