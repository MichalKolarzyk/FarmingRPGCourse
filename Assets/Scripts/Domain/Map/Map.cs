using System;

[Serializable]
public class Map : Entity{
  public MapProperty canNotDig = new();
  public MapProperty canNotDropItem = new();

  public bool CanDig(Position position) => !canNotDig.Check(position);
  public bool CanDropItem(Position position) => !canNotDropItem.Check(position);
}