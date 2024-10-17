
public class PlayerInventoryContext : Context<Inventory>
{
    void Awake(){
        var repository = FindObjectOfType<Repository>();
        model = repository.Data.playerInventory;
        model.OnDomainEvent += Publish;
    }
}
