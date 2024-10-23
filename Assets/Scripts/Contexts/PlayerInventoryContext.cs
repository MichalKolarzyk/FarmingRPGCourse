
public class PlayerInventoryContext : Context<Inventory>
{
    public override void Set(ref Inventory model)
    {
        model ??= new Inventory(Settings.inventory.playerInitialInventoryCapacity);
        this.model = model;
        this.model.OnDomainEvent += eventBus.Publish;
        model.Start();
    }
}
