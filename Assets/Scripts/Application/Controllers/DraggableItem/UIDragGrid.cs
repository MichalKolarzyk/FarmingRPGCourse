using UnityEngine;

public class DraggableItem : MonoBehaviour{
  [SerializeField] private UIDragGridSnap gridSnap;
  [SerializeField] private UIDragGridItemImage itemImage;

  public void Show(bool isGreen, ItemInfo itemInfo){
    gridSnap.Show(isGreen);
    itemImage.Show(itemInfo);
  }

  public void Hide(){
    gridSnap.Hide();
    itemImage.Hide();
  }

  public void SetPosition(Vector3 screenPosition){
    gridSnap.SetPosition(screenPosition);
    itemImage.SetPosition(screenPosition);
  }
}