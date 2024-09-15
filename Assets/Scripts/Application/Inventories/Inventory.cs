using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryModel inventoryModel = new(Settings.inventory.playerInitialInventoryCapacity);

    public void AddToInventory(Item item){
        var inventoryItem = new InventoryItemModel{
            itemDefinition = item.itemInfo.itemDefinition,
            quantity = 1,
        };
        if(inventoryModel.TryAdd(inventoryItem)){
            item.gameObject.SetActive(false);
        }
    }
}
