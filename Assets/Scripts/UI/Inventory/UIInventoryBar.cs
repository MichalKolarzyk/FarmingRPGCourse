using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    public Inventory inventory;
    private RectTransform rectTransform;
    private bool isInventoryBarPositionBottom = true;
    Camera mainCamera;
    UIInventorySlot[] inventorySlots;
    void Awake()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        inventorySlots = GetComponentsInChildren<UIInventorySlot>();
    }

    void Update()
    {
        SwitchInventoryBarPosition();
    }


    void OnEnable()
    {
        inventory.inventoryModel.OnInventoryUpdated.Subscribe(OnInventoryUpdated);
    }

    void OnDisable()
    {
        inventory.inventoryModel.OnInventoryUpdated.Unsubscribe(OnInventoryUpdated);
    }

    void OnInventoryUpdated(InventoryModel inventoryModel)
    {
        var itemCount = inventoryModel?.items?.Count ?? 0;
        for(int i = 0; i < itemCount; i++){
            inventorySlots[i].SetModel(inventoryModel?.items[i]);
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
