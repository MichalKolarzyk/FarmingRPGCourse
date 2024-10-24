using System;

[Serializable]
public class Map : Entity{
  public MapProperty canNotDig = new();
  public MapProperty canNotDrop = new();

  public bool CanDig(Position position) => !canNotDig.Check(position);
  public bool CanDrop(Position position) => !canNotDrop.Check(position);
}