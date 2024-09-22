using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryModel model = new(Settings.inventory.playerInitialInventoryCapacity);

    public void AddToInventory(Item item){
        var inventoryItem = new InventoryItemModel{
            itemDefinition = item.itemInfo.itemDefinition,
            quantity = 1,
        };
        if(model.TryAdd(inventoryItem)){
            item.gameObject.SetActive(false);
        }
    }
}
