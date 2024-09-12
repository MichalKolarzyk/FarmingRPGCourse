using System;
using UnityEngine;

public class InventoryPublisher : MonoBehaviour
{
    public event Action<InventoryModel> InventoryUpdatedEvent;

    public void Publish(InventoryModel inventoryModel){
        InventoryUpdatedEvent?.Invoke(inventoryModel);
    }
}
