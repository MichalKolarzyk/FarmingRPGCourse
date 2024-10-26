
using UnityEngine;
using UnityEngine.UIElements;

public class UIGameMonoBehaviour : MonoBehaviour
{
    private UIClockController clockController;
    private Context<GameTime> gameTimeContext;
    private UIDocument uiDocument;
    void Awake(){
        uiDocument = GetComponent<UIDocument>();
        gameTimeContext = FindAnyObjectByType<Context<GameTime>>();
    }

    void OnEnable()
    {
        var header = uiDocument.rootVisualElement.Q("Header");
        header.pickingMode = PickingMode.Ignore;
        
        var view = uiDocument.rootVisualElement.Q("ClockView");
        var clockView = new UIClockView(view);
        clockController = new UIClockController(gameTimeContext, clockView);
        clockController.Enable();
    }

    void OnDisable()
    {
        clockController.Disable();
    }
}
