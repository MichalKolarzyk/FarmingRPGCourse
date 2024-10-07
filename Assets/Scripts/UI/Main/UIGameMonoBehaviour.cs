
using UnityEngine;
using UnityEngine.UIElements;

public class UIGameMonoBehaviour : MonoBehaviour
{
    private UIClockController clockController;
    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        
        var clockVisualElement = uiDocument.rootVisualElement.Q("ClockView");
        var gameTimeModel = FindAnyObjectByType<ObjectMonoBehaviour<GameTimeModel>>();
        var clockView = new UIClockView(clockVisualElement);
        clockController = new UIClockController(gameTimeModel.GetModel(), clockView);
        clockController.Enable();
    }

    void OnDisable()
    {
        clockController.Disable();
    }
}
