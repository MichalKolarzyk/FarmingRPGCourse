using UnityEngine;

[RequireComponent(typeof(ObjectMonoBehaviour<InventoryModel>))]
public class PickUpItemBehaviour : MonoBehaviour
{
    private ObjectMonoBehaviour<InventoryModel> inventory;
    private InventoryModel inventoryModel;
    private ItemModelParent itemModelParent;

    void Awake()
    {
        inventory = GetComponent<Inventory>();
        inventoryModel = inventory.GetModel();
        itemModelParent = FindObjectOfType<ItemParent>().GetModel();
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Item item))
        {
            var canAddToInventory = inventoryModel.TryAdd(item.ToInventoryItemModel());
            if(!canAddToInventory)
                return;
            
            Destroy(item.gameObject);
        }
    }
}
