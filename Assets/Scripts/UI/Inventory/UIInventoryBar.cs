using System;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryBar : MonoBehaviour
{
    private PlayerInventoryContext inventoryContext;
    private Inventory model;
    private DraggableItem draggedItem;
    private DraggableItemFactory draggableItemFactory;
    private RectTransform rectTransform;
    private bool isInventoryBarPositionBottom = true;
    private UIInventorySlot[] uiInventorySlots;
    private MainCameraService mainCameraService;
    private ScriptableObjectService<ItemInfo> itemInfoScriptableObjectService;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private DropItemFromInventoryAction dropItemFromInventoryAction;
    public event EventHandler<PointerEventData> OnPointerEnterEvent;
    public event EventHandler<PointerEventData> OnPointerExitEvent;

    void OnEnable()
    {
        dropItemFromInventoryAction = FindAnyObjectByType<DropItemFromInventoryAction>();
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        var player = FindObjectOfType<Player>();
        inventoryContext = player.GetComponent<PlayerInventoryContext>();
        itemInfoScriptableObjectService = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>();
        draggableItemFactory = ServiceContainer.Instance.Get<DraggableItemFactory>();
        inventoryContext.Subscribe<OnInventoryUpdated>(OnInventoryUpdated);
        model = inventoryContext.Model();

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
        inventoryContext.Unsubscribe<OnInventoryUpdated>(OnInventoryUpdated);

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
        OnInventoryUpdated(new OnInventoryUpdated(model));
    }

    void Update()
    {
        SwitchInventoryBarPosition();
    }

    private void OnPointerClickEventHandler(object sender, PointerEventData e)
    {
        if(e.dragging) return;
        var slot = sender as UIInventorySlot;
        model.SetSeletedSlot(slot.model);
    }

    private void OnBeginDragEventHandler(object sender, PointerEventData e)
    {
        var slot = sender as UIInventorySlot;
        var slotModel = slot.model;
        if (slotModel == null || slotModel.IsEmpty)
            return;

        draggedItem = draggableItemFactory.Create(transform.parent);
        var itemInfo = itemInfoScriptableObjectService.GetById(slotModel.content.itemDefinition.GetId());
        draggedItem.Show(true, itemInfo);
    }

    private void OnDragEvenHandler(object sender, PointerEventData e)
    {
        if (draggedItem == null)
            return;
        var uiSlot = sender as UIInventorySlot;
        draggedItem.SetPosition(Input.mousePosition);
        var canDrop = dropItemFromInventoryAction.CanDrop(uiSlot.model.content.itemDefinition, draggedItem.GetGridPosition());
        draggedItem.SetGridSnap(canDrop);
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
            var inventoryItem = InventoryItem.One(slotItemDefinition);
            dropItemFromInventoryAction.Execute(inventoryContext.Model(), inventoryItem, draggedItem.GetGridPosition());
        }

        draggedItem.Hide();

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


    void OnInventoryUpdated(OnInventoryUpdated args)
    {
        var inventory = args.Value;
        var slotsLength = uiInventorySlots.Length;
        for (int i = 0; i < slotsLength; i++)
        {
            var item = inventory.slots.ElementAtOrDefault(i);
            uiInventorySlots[i].SetModel(item);
        }
    }

    private void SwitchInventoryBarPosition()
    {
        Vector3 viewportPosition = mainCameraService.GetFollowViewport(cinemachineVirtualCamera);

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
