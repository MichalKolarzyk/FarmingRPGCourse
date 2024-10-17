using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public Sprite transparentSlotSprite;
    public TextMeshProUGUI text;
    public InventorySlot model;

    private Color unselectColor;
    private Color selectColor;

    public event EventHandler<PointerEventData> OnBeginDragEvent;
    public event EventHandler<PointerEventData> OnDragEven;
    public event EventHandler<PointerEventData> OnEndDragEvent;
    public event EventHandler<PointerEventData> OnPointerEnterEvent;
    public event EventHandler<PointerEventData> OnPointerExitEvent;
    public event EventHandler<PointerEventData> OnPointerClickEvent;

    void Start(){
        unselectColor = inventorySlotHighlight.color;
        selectColor = new Color(unselectColor.r, unselectColor.g, unselectColor.b, 1);
    }

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

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerClickEvent?.Invoke(this, eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke(this, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent?.Invoke(this, eventData);
    }

    public void SetModel(InventorySlot inventorySlotModel)
    {
        if (inventorySlotModel.IsEmpty)
        {
            model = inventorySlotModel;
            inventorySlotImage.sprite = transparentSlotSprite;
            text.text = "";
            inventorySlotHighlight.color = unselectColor;
            return;
        }

        model = inventorySlotModel;
        var service = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>();
        inventorySlotImage.sprite = service.GetValue(i => i.itemDefinition.description == inventorySlotModel.content.itemDefinition.description).sprite;
        
        text.text = inventorySlotModel.content.quantity.ToString();
        inventorySlotHighlight.color = model.IsSelected ? selectColor : unselectColor;
    }
}
