public class PlayerPositionContext : Context<Position>{
  void Awake(){
    var repository = FindObjectOfType<Repository>();
    repository.Data.playerPosition ??= Position.FromVector(transform.position);
    model = repository.Data.playerPosition;
  }

  void Start(){
    transform.position = model.ToVector3();
  }


  void Update(){
    model.x = transform.position.x;
    model.y = transform.position.y;
  }
}