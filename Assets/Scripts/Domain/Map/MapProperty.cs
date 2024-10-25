using System;
using System.Collections.Generic;

[Serializable]
public class MapProperty{
  public List<string> values = new();

  public void Set(Position position){
    values.Add(PositionToString(position));
  }

  public void UnSet(Position position){
    values.Remove(PositionToString(position));
  }

  public bool Check(Position position){
    return values.Contains(PositionToString(position)); 
  }

  private string PositionToString(Position position){
    return $"x{position.x}y{position.y}";
  }
}