using UnityEngine;

public class DropItemFromInventoryAction : MonoBehaviour{
  
  private CollectionContext<Item> itemCollectionContext;
  private Context<Map> mapContext;
  private Grid grid;
  void Awake(){
    itemCollectionContext = FindObjectOfType<CollectionContext<Item>>();
    mapContext = FindObjectOfType<Context<Map>>();
    grid = FindAnyObjectByType<Grid>();
  }

  public bool Execute(Inventory inventory, InventoryItem inventoryItem, Vector3 position){
    var canRemove = inventory.TryRemove(inventoryItem);
    if(!canRemove)
      return false;

    var itemPosition = Position.FromVector(grid.LocalToCell(position));
    var map = mapContext.Model();

    if(!map.CanDrop(itemPosition))
      return false;

    var item = new Item(inventoryItem.itemDefinition, itemPosition);
    itemCollectionContext.Add(item);
    return true;
  }
}