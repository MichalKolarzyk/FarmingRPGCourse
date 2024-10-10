using UnityEngine;
using UnityEngine.UIElements;

public class UIFadeImageMonoBehaviour : MonoBehaviour
{
    UIFadeImageController uIFadeImageController;
    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        
        var sceneModel = FindAnyObjectByType<SceneObjectMonoBehaviour>();
        var fadeImageVisualElement = uiDocument.rootVisualElement.Q("Background");
        var view = new UIFadeImageView(fadeImageVisualElement);
        uIFadeImageController = new UIFadeImageController(view, sceneModel);
        uIFadeImageController.Enable();
    }

    void OnDisable()
    {
        uIFadeImageController.Disable();
    }
}
