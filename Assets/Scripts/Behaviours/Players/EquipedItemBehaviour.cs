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
    movementContext.Subscribe<OnIsCarryingItemChangeEvent>(OnIsCarryingItemChangeEventHandler);

    inventoryContext = GetComponentInParent<Context<Inventory>>();
    inventoryContext.Subscribe<OnSelectedSlotChange>(OnSelectedSlotChangeEventHandler);
  }

  private void OnSelectedSlotChangeEventHandler(OnSelectedSlotChange args)
  {
    selectedSlot = args.Value.GetSelectedSlot();
    UpdateSprite();
  }

  void OnDisable()
  {
    movementContext.Unsubscribe<OnIsCarryingItemChangeEvent>(OnIsCarryingItemChangeEventHandler);
    inventoryContext.Unsubscribe<OnSelectedSlotChange>(OnSelectedSlotChangeEventHandler);
  }
  private void OnIsCarryingItemChangeEventHandler(OnIsCarryingItemChangeEvent args)
  {
    var movement = args.Value;
    isCarrying = movement.isCarrying;
    UpdateSprite();
  }

  private void UpdateSprite()
  {
    if (isCarrying == false || selectedSlot == null || selectedSlot.IsEmpty)
      spriteRenderer.sprite = defaultSprite;
    else
      spriteRenderer.sprite = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>()
        .GetById(selectedSlot.content.itemDefinition.GetId()).sprite;
  }
}
