using System;
using UnityEngine;

public class DraggableItem : MonoBehaviour{
  [SerializeField] private UIDragGridSnap gridSnap;
  [SerializeField] private UIDragGridItemImage itemImage;

  public void Show(bool isGreen, ItemInfo itemInfo){
    gridSnap.Show(isGreen);
    itemImage.Show(itemInfo);
  }

  public Vector3 GetGridPosition(){
    return gridSnap.gridPosition;
  }

  public void Hide(){
    gridSnap.Hide();
    itemImage.Hide();
    Destroy(gameObject);
  }

  public void SetPosition(Vector3 screenPosition){
    gridSnap.SetPosition(screenPosition);
    itemImage.SetPosition(screenPosition);
  }

    internal void SetGridSnap(bool isGreen)
    {
        gridSnap.Show(isGreen);
    }
}