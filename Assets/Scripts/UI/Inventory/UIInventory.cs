using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventory : MonoBehaviour
{
    private UIInventoryBar uIInventoryBar;
    private UIPopup uIInventoryPopup;
    void Awake(){
        uIInventoryBar = GetComponentInChildren<UIInventoryBar>();
        uIInventoryPopup = FindObjectOfType<UIPopup>();
    }

    void Start(){
        uIInventoryBar.OnPointerEnterEvent += OnPointerEnterEventHandler;
        uIInventoryBar.OnPointerExitEvent += OnPointerExitEventHandler;
    }

    private void OnPointerExitEventHandler(object sender, PointerEventData e)
    {
        uIInventoryPopup.Hide();
    }

    private void OnPointerEnterEventHandler(object sender, PointerEventData e)
    {
        var uiSlot = sender as UIInventorySlot;
        var itemDefinition = uiSlot.model.content.itemDefinition;
        uIInventoryPopup.Show(itemDefinition);
    }
}
