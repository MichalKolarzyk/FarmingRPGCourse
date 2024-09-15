using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public Sprite transparentSlotSprite;
    public TextMeshProUGUI text;
    public InventoryItemModel model;

    public event EventHandler<PointerEventData> OnBeginDragEvent;
    public event EventHandler<PointerEventData> OnDragEven;
    public event EventHandler<PointerEventData> OnEndDragEvent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragEvent?.Invoke(this, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragEven?.Invoke(this, eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragEvent?.Invoke(this, eventData);
    }

    public void SetModel(InventoryItemModel inventoryItemModel)
    {
        if (inventoryItemModel == null)
        {
            model = null;
            inventorySlotImage.sprite = transparentSlotSprite;
            text.text = "";
        }
        else
        {
            model = inventoryItemModel;
            inventorySlotImage.sprite = inventoryItemModel.itemDefinition.sprite;
            text.text = inventoryItemModel.quantity.ToString();
        }
    }
}
