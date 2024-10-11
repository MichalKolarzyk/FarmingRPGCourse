using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryBar : MonoBehaviour
{
    public Inventory inventory;
    private InventoryModel model;
    public GameObject draggedItemPrefab;
    GameObject draggedItem;
    private RectTransform rectTransform;
    private bool isInventoryBarPositionBottom = true;
    UIInventorySlot[] uiInventorySlots;
    ScriptableObjectService<ItemInfo> itemInfosService;
    MainCameraService mainCameraService;

    public event EventHandler<PointerEventData> OnPointerEnterEvent;
    public event EventHandler<PointerEventData> OnPointerExitEvent;

    void OnEnable()
    {
        model = inventory.GetModel();
        model.OnInventoryUpdated += OnInventoryUpdated;

        foreach (var inventorySlot in uiInventorySlots)
        {
            inventorySlot.OnBeginDragEvent += OnBeginDragEventHandler;
            inventorySlot.OnDragEven += OnDragEvenHandler;
            inventorySlot.OnEndDragEvent += OnEndDragEventHandler;
            inventorySlot.OnPointerEnterEvent += OnPointerEnterEventHandler;
            inventorySlot.OnPointerExitEvent += OnPointerExitEventHandler;
            inventorySlot.OnPointerClickEvent += OnPointerClickEventHandler;
        }
    }

    void OnDisable()
    {
        model.OnInventoryUpdated -= OnInventoryUpdated;

        foreach (var inventorySlot in uiInventorySlots)
        {
            inventorySlot.OnBeginDragEvent -= OnBeginDragEventHandler;
            inventorySlot.OnDragEven -= OnDragEvenHandler;
            inventorySlot.OnEndDragEvent -= OnEndDragEventHandler;
            inventorySlot.OnPointerEnterEvent -= OnPointerEnterEventHandler;
            inventorySlot.OnPointerExitEvent -= OnPointerExitEventHandler;
            inventorySlot.OnPointerClickEvent -= OnPointerClickEventHandler;
        }
    }
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        uiInventorySlots = GetComponentsInChildren<UIInventorySlot>();
        mainCameraService = ServiceContainer.Instance.Get<MainCameraService>();
    }

    void Start()
    {
        itemInfosService = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>();
        OnInventoryUpdated(model);
    }

    void Update()
    {
        SwitchInventoryBarPosition();
    }

    private void OnPointerClickEventHandler(object sender, PointerEventData e)
    {
        var slot = sender as UIInventorySlot;
        model.SetSeletedSlot(slot.model);
    }

    private void OnBeginDragEventHandler(object sender, PointerEventData e)
    {
        var slot = sender as UIInventorySlot;
        var slotModel = slot.model;
        if (slotModel == null)
            return;

        draggedItem = Instantiate(draggedItemPrefab, transform);
        var image = draggedItem.GetComponentInChildren<Image>();
        image.sprite = slotModel.content.itemDefinition.sprite;

    }

    private void OnDragEvenHandler(object sender, PointerEventData e)
    {
        if (draggedItem == null)
            return;

        draggedItem.transform.position = Input.mousePosition;
    }

    private void OnEndDragEventHandler(object sender, PointerEventData e)
    {
        if (draggedItem == null)
            return;

        var uiSlot = sender as UIInventorySlot;
        var slotItemDefinition = uiSlot.model.content.itemDefinition;
        if (EndDragOnUIInventorySlot(out var uIInventorySlot))
        {
            model.SwapItems(uiSlot.model, uIInventorySlot.model);
        }
        else
        {
            var canRemove = model.TryRemove(new InventoryItemModel
            {
                itemDefinition = slotItemDefinition,
                quantity = 1,
            });

            if (canRemove){
                var itemFactory = ServiceContainer.Instance.Get<ItemFactory>();
                var wordMousePosition = mainCameraService.GetWordMousePosition();
                var itemInfo = itemInfosService.GetValue(i => i.itemDefinition == slotItemDefinition);
                var item = itemFactory.Create(wordMousePosition, itemInfo);
            }
        }

        Destroy(draggedItem);

        bool EndDragOnUIInventorySlot(out UIInventorySlot uIInventorySlot)
        {
            uIInventorySlot = null;
            var endDragGameObject = e.pointerCurrentRaycast.gameObject;
            if (endDragGameObject == null)
                return false;

            uIInventorySlot = e.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>();
            if (uIInventorySlot == null)
                return false;

            return true;
        }
    }

    private void OnPointerExitEventHandler(object sender, PointerEventData e)
    {
        OnPointerExitEvent?.Invoke(sender, e);
    }

    private void OnPointerEnterEventHandler(object sender, PointerEventData e)
    {
        OnPointerEnterEvent?.Invoke(sender, e);
    }


    void OnInventoryUpdated(InventoryModel inventoryModel)
    {
        var slotsLength = uiInventorySlots.Length;
        for (int i = 0; i < slotsLength; i++)
        {
            var item = inventoryModel.slots.ElementAtOrDefault(i);
            uiInventorySlots[i].SetModel(item);
        }
    }

    private void SwitchInventoryBarPosition()
    {
        Vector3 viewportPosition = mainCameraService.GetFollowViewport();

        if (viewportPosition.y > 0.3f && isInventoryBarPositionBottom == false)
        {
            rectTransform.pivot = new Vector2(0.5f, 0f);
            rectTransform.anchorMin = new Vector2(0.5f, 0f);
            rectTransform.anchorMax = new Vector2(0.5f, 0f);
            rectTransform.anchoredPosition = new Vector2(0, 2.5f);
            isInventoryBarPositionBottom = true;
        }
        else if (viewportPosition.y <= 0.3f && isInventoryBarPositionBottom == true)
        {
            rectTransform.pivot = new Vector2(0.5f, 1f);
            rectTransform.anchorMin = new Vector2(0.5f, 1f);
            rectTransform.anchorMax = new Vector2(0.5f, 1f);
            rectTransform.anchoredPosition = new Vector2(0, -2.5f);
            isInventoryBarPositionBottom = false;
        }
    }
}
