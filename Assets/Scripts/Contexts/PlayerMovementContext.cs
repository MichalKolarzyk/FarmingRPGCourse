public class PlayerMovementContext : Context<Movement>
{
    public override void Set(ref Movement model)
    {
        model ??= new Movement(new MovementDefinition(Settings.playerMovement.walkingSpeed, Settings.playerMovement.runnintSpeed));
        this.model = model;
        this.model.OnDomainEvent += eventBus.Publish;
        this.model.Start();
    }
}
