using UnityEngine;

public class Backpack : MonoBehaviour
{
    private InventoryModel inventoryModel;

    void Awake(){
        inventoryModel = new InventoryModel(Settings.inventory.playerInitialInventoryCapacity);
    }

    public void PickUpItem(Item item){
        var inventoryItem = new InventoryItemModel{
            itemDefinition = item.itemInfo.itemDefinition,
            quantity = 1,
        };
        if(inventoryModel.TryAdd(inventoryItem)){
            item.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.TryGetComponent(out Item item)){
            PickUpItem(item);
        }
    }
}
