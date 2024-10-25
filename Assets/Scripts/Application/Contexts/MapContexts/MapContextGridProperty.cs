using UnityEngine;
using UnityEngine.Tilemaps;

public class MapContextGridProperty : MonoBehaviour
{
  public MapContextGridPropertyType type;
  public Tilemap tilemap;

  public MapProperty GetMapProperty()
  {
    var mapProperty = new MapProperty();
    tilemap = GetComponent<Tilemap>();
    var tilemapOrgin = tilemap.transform.position;
    BoundsInt bounds = tilemap.cellBounds;

    for (int x = bounds.xMin; x < bounds.xMax; x++)
    {
      for (int y = bounds.yMin; y < bounds.yMax; y++)
      {
        Vector3Int tilePosition = new(x, y, 0);
        TileBase tile = tilemap.GetTile(tilePosition);

        if(tile == null)
          continue;

        mapProperty.Set(Position.FromVector(tilePosition + tilemapOrgin));
      }
    }

    return mapProperty;
  }
}

public enum MapContextGridPropertyType
{
  CanPlaceFurniture,
  CanDropItem,
  CanDig,
  Path,
  NPCObstacle,
}