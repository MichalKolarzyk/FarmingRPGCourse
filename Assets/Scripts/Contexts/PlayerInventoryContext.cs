
public class PlayerInventoryContext : Context<Inventory>
{
    void Awake(){
        var repository = FindObjectOfType<Repository>();
        repository.Data.playerInventory ??= new Inventory(Settings.inventory.playerInitialInventoryCapacity);
        model = repository.Data.playerInventory;
    }

    void Start(){
        model.Start();
    }
}
