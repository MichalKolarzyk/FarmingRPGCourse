public class PlayerMovementContext : Context<Movement>
{
    void Awake(){
        var repository = FindObjectOfType<Repository>();
        model = repository.Data.playerMovement;
    }

    void Start(){
        model.Start();
    }
}
