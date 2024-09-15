using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIInventorySlot : MonoBehaviour
{
    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public TextMeshProUGUI text;


    public void SetModel(InventoryItemModel inventoryItemModel){
        if(inventoryItemModel == null)
            return;
            
        inventorySlotImage.sprite = inventoryItemModel.itemDefinition.sprite;
        text.text = inventoryItemModel.quantity.ToString();
    }
}
