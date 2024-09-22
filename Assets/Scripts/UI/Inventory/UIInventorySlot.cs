using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public Sprite transparentSlotSprite;
    public TextMeshProUGUI text;
    public InventorySlotModel model;

    public event EventHandler<PointerEventData> OnBeginDragEvent;
    public event EventHandler<PointerEventData> OnDragEven;
    public event EventHandler<PointerEventData> OnEndDragEvent;
    public event EventHandler<PointerEventData> OnPointerEnterEvent;
    public event EventHandler<PointerEventData> OnPointerExitEvent;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke(this, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent?.Invoke(this, eventData);
    }

    public void SetModel(InventorySlotModel inventorySlotModel)
    {
        if (inventorySlotModel.IsEmpty)
        {
            model = inventorySlotModel;
            inventorySlotImage.sprite = transparentSlotSprite;
            text.text = "";
        }
        else
        {
            model = inventorySlotModel;
            inventorySlotImage.sprite = inventorySlotModel.content.itemDefinition.sprite;
            text.text = inventorySlotModel.content.quantity.ToString();
        }
    }
}
