using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private UIInventoryBar uIInventoryBar;
    private UIInventoryPopup uIInventoryPopup;
    private VerticalLayoutGroup verticalLayoutGroup;
    void Awake(){
        uIInventoryBar = GetComponentInChildren<UIInventoryBar>();
        uIInventoryPopup = GetComponentInChildren<UIInventoryPopup>();
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
        uIInventoryPopup.transform.position = new Vector3(uiSlot.transform.position.x, uIInventoryPopup.transform.position.y, uIInventoryPopup.transform.position.z);
    }
}
