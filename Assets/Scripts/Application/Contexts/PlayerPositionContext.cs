public class PlayerPositionContext : Context<Position>
{
  public override void Set(ref Position model)
  {
    model ??= Position.FromVector(transform.position);
    this.model = model;
    transform.position = this.model.ToVector3();
  }



  void Update()
  {
    if(model == null)
      return;
      
    model.x = transform.position.x;
    model.y = transform.position.y;
  }
}