using UnityEngine;

public class EquipedItemBehaviour : MonoBehaviour
{

  private Context<Movement> movementContext;
  private Context<Inventory> inventoryContext;
  private SpriteRenderer spriteRenderer;
  public Sprite defaultSprite;
  private InventorySlot selectedSlot;
  private bool isCarrying;

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }


  void OnEnable()
  {
    movementContext = GetComponentInParent<Context<Movement>>();
    movementContext.Get().OnIsCarryingItemChangeEvent += OnIsCarryingItemChangeEventHandler;

    inventoryContext = GetComponentInParent<Context<Inventory>>();
    inventoryContext.Get().OnSelectedSlotChange += OnSelectedSlotChangeEventHandler;
  }

  private void OnSelectedSlotChangeEventHandler(Inventory inventory, InventorySlot prevSlot)
  {
    selectedSlot = inventory.GetSelectedSlot();
    UpdateSprite();
  }

  void OnDisable()
  {
    movementContext.Get().OnIsCarryingItemChangeEvent -= OnIsCarryingItemChangeEventHandler;
    inventoryContext.Get().OnSelectedSlotChange -= OnSelectedSlotChangeEventHandler;
  }
  private void OnIsCarryingItemChangeEventHandler(Movement movement)
  {
    UpdateSprite();
  }

  private void UpdateSprite()
  {
    if (selectedSlot == null || selectedSlot.IsEmpty)
      spriteRenderer.sprite = defaultSprite;
    else
      spriteRenderer.sprite = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>()
        .GetValue(i => i.itemDefinition.description == selectedSlot.content.itemDefinition.description).sprite;
  }
}
