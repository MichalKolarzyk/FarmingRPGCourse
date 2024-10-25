using UnityEngine;

public class DropItemFromInventoryAction : MonoBehaviour{
  
  private CollectionContext<Item> itemCollectionContext;
  private PlayerPositionContext playerPositionContext;
  private Context<Map> mapContext;
  private Grid grid;
  void Awake(){
    playerPositionContext = FindAnyObjectByType<PlayerPositionContext>();
    itemCollectionContext = FindObjectOfType<CollectionContext<Item>>();
    mapContext = FindObjectOfType<Context<Map>>();
    grid = FindAnyObjectByType<Grid>();
  }

  public bool Execute(Inventory inventory, InventoryItem inventoryItem, Vector3 position){
    var playerPosition = playerPositionContext.Model();
    var itemPosition = Position.FromVector(grid.LocalToCell(position));

    var distans = Vector3.Distance(playerPosition.ToVector3(), itemPosition.ToVector3());
    if(distans >= inventoryItem.itemDefinition.useRadius)
      return false;

    var map = mapContext.Model();
    if(!map.CanDropItem(itemPosition))
      return false;

    var canRemove = inventory.TryRemove(inventoryItem);
    if(!canRemove)
      return false;

    var item = new Item(inventoryItem.itemDefinition, itemPosition);
    itemCollectionContext.Add(item);
    return true;
  }
}