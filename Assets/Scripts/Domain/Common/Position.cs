using System;
using UnityEngine;

[Serializable]
public class Position
{
  public float x;
  public float y;
  public Position(float x, float y)
  {
    this.x = x;
    this.y = y;
  }

  public Vector3 ToVector3()
  {
    return new Vector3(x, y, 0);
  }

  public static Position FromVector(Vector3 vector3)
  {
    return new Position(vector3.x, vector3.y);
  }
}