using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryBar : MonoBehaviour
{
    public Inventory inventory;
    public GameObject draggedItemPrefab;
    GameObject draggedItem;
    private RectTransform rectTransform;
    private bool isInventoryBarPositionBottom = true;
    Camera mainCamera;
    UIInventorySlot[] inventorySlots;
    ScriptableObjectService<ItemInfo> itemInfosService;
    ItemFactory itemFactory;


    void Awake()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        inventorySlots = GetComponentsInChildren<UIInventorySlot>();
    }

    void Start(){
        itemInfosService = ServiceContainer.Instance.GetComponent<ScriptableObjectService<ItemInfo>>();
        itemFactory = ServiceContainer.Instance.GetComponent<ItemFactory>();
    }

    void Update()
    {
        SwitchInventoryBarPosition();
    }

    void OnEnable()
    {
        inventory.inventoryModel.OnInventoryUpdated.Subscribe(OnInventoryUpdated);

        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.OnBeginDragEvent += OnBeginDragEventHandler;
            inventorySlot.OnDragEven += OnDragEvenHandler;
            inventorySlot.OnEndDragEvent += OnEndDragEventHandler;
        }
    }

    void OnDisable()
    {
        inventory.inventoryModel.OnInventoryUpdated.Unsubscribe(OnInventoryUpdated);

        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.OnBeginDragEvent -= OnBeginDragEventHandler;
            inventorySlot.OnDragEven -= OnDragEvenHandler;
            inventorySlot.OnEndDragEvent -= OnEndDragEventHandler;
        }
    }

    private void OnBeginDragEventHandler(object sender, PointerEventData e)
    {
        var slot = sender as UIInventorySlot;
        var slotModel = slot.model;
        if (slotModel == null)
            return;

        draggedItem = Instantiate(draggedItemPrefab, transform);
        var image = draggedItem.GetComponentInChildren<Image>();
        image.sprite = slotModel.itemDefinition.sprite;

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
        var slot = sender as UIInventorySlot;
        var itemDefinitionToRemove = slot.model.itemDefinition;

        var canRemove = inventory.inventoryModel.TryRemoveItem(new InventoryItemModel{
            itemDefinition = itemDefinitionToRemove,
            quantity = 1,
        });

        if(!canRemove)
            return;

        var wordPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
        var itemInfo = itemInfosService.GetValue(i => i.itemDefinition == itemDefinitionToRemove);
        var item = itemFactory.Create(wordPosition, itemInfo);
        Destroy(draggedItem);
    }

    void OnInventoryUpdated(InventoryModel inventoryModel)
    {
        var slotsLength = inventorySlots.Length;
        for (int i = 0; i < slotsLength; i++)
        {
            var item = inventoryModel.items.ElementAtOrDefault(i);
            inventorySlots[i].SetModel(item);
        }
    }

    private void SwitchInventoryBarPosition()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(inventory.transform.position);

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
