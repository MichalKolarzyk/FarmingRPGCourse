using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    public Inventory inventory;
    private RectTransform rectTransform;
    private bool isInventoryBarPositionBottom = true;
    Camera mainCamera;
    void Awake()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
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
        print("Inventory updated from UI");
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
