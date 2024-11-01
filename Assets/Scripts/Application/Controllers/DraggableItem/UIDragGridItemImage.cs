using UnityEngine;
using UnityEngine.UI;

public class UIDragGridItemImage : MonoBehaviour
{
  public Image image;


  public void Show(ItemInfo itemInfo)
  {
    if (itemInfo.IsEmpty())
      return;

    image.sprite = itemInfo.sprite;
  }

  public void Hide()
  {
    image.sprite = null;
  }

  public void SetPosition(Vector3 screenPosition)
  {
    transform.position = screenPosition;
  }
}