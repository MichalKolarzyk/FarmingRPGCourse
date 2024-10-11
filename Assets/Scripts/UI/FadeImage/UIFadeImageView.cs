using UnityEngine;
using UnityEngine.UIElements;

public class UIFadeImageView{

  private readonly VisualElement visualElement;
  public UIFadeImageView(VisualElement visualElement)
  {
    this.visualElement = visualElement;
    visualElement.pickingMode = PickingMode.Ignore;
  }

  public void SetColor(Color color){
    visualElement.style.backgroundColor = color;
  }
}