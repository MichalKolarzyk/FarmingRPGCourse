public class PlayerPositionContext : Context<Position>
{
  public override void Set(ref Position model)
  {
    var currentSceneContext = FindObjectOfType<CurrentSceneContext>();
    model ??= currentSceneContext.defaultSceneSpawnPointInfo.definition.GetPositoin();
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