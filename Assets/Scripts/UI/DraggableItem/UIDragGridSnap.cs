using UnityEngine;
using UnityEngine.UI;

public class UIDragGridSnap : MonoBehaviour{
  public Sprite redGrid;
  public Sprite greenGrid;
  private Image gridImage;
  private Grid grid;
  public Vector3 gridPosition;

  void Awake(){
    gridImage = GetComponent<Image>();
    grid = FindObjectOfType<Grid>();
  }

  public void Show(bool isGreen){
    var activeSprite = isGreen ? greenGrid : redGrid;
    gridImage.sprite = activeSprite;
  }

  public void Hide(){
    gridImage.sprite = null;
  }

  public void SetPosition(Vector3 screenPosition){
    var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    gridPosition = grid.LocalToCell(worldPosition) + grid.cellSize/2;
    transform.position =  Camera.main.WorldToScreenPoint(gridPosition);
    //transform.position = screenPosition;
  }
}