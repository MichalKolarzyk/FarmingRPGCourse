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
    movementContext.Subscribe<Movement.OnIsCarryingItemChangeEvent>(OnIsCarryingItemChangeEventHandler);

    inventoryContext = GetComponentInParent<Context<Inventory>>();
    inventoryContext.Subscribe<Inventory.OnSelectedSlotChange>(OnSelectedSlotChangeEventHandler);
  }

  private void OnSelectedSlotChangeEventHandler(Inventory.OnSelectedSlotChange domainEvent)
  {
    selectedSlot = domainEvent.inventorySlot;
    UpdateSprite();
  }

  void OnDisable()
  {
    movementContext.Unsubscribe<Movement.OnIsCarryingItemChangeEvent>(OnIsCarryingItemChangeEventHandler);
    inventoryContext.Unsubscribe<Inventory.OnSelectedSlotChange>(OnSelectedSlotChangeEventHandler);
  }
  private void OnIsCarryingItemChangeEventHandler(Movement.OnIsCarryingItemChangeEvent domainEvent)
  {
    isCarrying = domainEvent.isCarrying;
    UpdateSprite();
  }

  private void UpdateSprite()
  {
    if (isCarrying == false || selectedSlot == null || selectedSlot.IsEmpty)
      spriteRenderer.sprite = defaultSprite;
    else
      spriteRenderer.sprite = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>()
        .GetValue(i => i.itemDefinition.description == selectedSlot.content.itemDefinition.description).sprite;
  }
}
