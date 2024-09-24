using UnityEngine;

[RequireComponent(typeof(ObjectMonoBehaviour<InventoryModel>))]
public class PickUpItemBehaviour : MonoBehaviour
{
    private ObjectMonoBehaviour<InventoryModel> inventory;
    private InventoryModel inventoryModel;

    void Awake()
    {
        inventory = GetComponent<Inventory>();
        inventoryModel = inventory.GetModel();
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Item item))
        {
            var canAddToInventory = inventoryModel.TryAdd(item.ToInventoryItemModel());
            if(!canAddToInventory)
                return;
            
            item.gameObject.SetActive(false);
        }
    }
}
