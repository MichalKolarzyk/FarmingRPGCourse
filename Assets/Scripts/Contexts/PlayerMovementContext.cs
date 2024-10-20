public class PlayerMovementContext : Context<Movement>
{
    void Awake(){
        var repository = FindObjectOfType<Repository>();
        repository.Data.playerMovement ??= new Movement(new MovementDefinition(Settings.playerMovement.walkingSpeed, Settings.playerMovement.runnintSpeed));
        model = repository.Data.playerMovement;
    }

    void Start(){
        model.Start();
    }
}
