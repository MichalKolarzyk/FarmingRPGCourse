using System;
using UnityEngine;

public class EquipedItemBehaviour : MonoBehaviour
{

  private MovementModel movementModel;
  private InventoryModel inventoryModel;
  private SpriteRenderer spriteRenderer;
  public Sprite defaultSprite;
  private bool isCarrying;

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }


  void OnEnable()
  {
    movementModel = GetComponentInParent<ObjectMonoBehaviour<MovementModel>>().GetModel();
    movementModel.OnIsCarryingItemChangeEvent += OnIsCarryingItemChangeEventHandler;
    isCarrying = movementModel.isCarrying;

    inventoryModel = GetComponentInParent<ObjectMonoBehaviour<InventoryModel>>().GetModel();
    inventoryModel.OnSelectedSlotChange += OnSelectedSlotChangeEventHandler;
  }

  private void OnSelectedSlotChangeEventHandler(object sender, InventorySlotModel e)
  {
    UpdateSprite();
  }

  void OnDisable()
  {
    movementModel.OnIsCarryingItemChangeEvent -= OnIsCarryingItemChangeEventHandler;
  }
  private void OnIsCarryingItemChangeEventHandler(object sender, bool e)
  {
    isCarrying = e;
    UpdateSprite();
  }

  private void UpdateSprite()
  {
    var selectedSlot = inventoryModel.GetSelectedSlot();
    if (isCarrying == false || selectedSlot == null || selectedSlot.IsEmpty)
      spriteRenderer.sprite = defaultSprite;
    else
      spriteRenderer.sprite = ServiceContainer.Instance.Get<ScriptableObjectService<ItemInfo>>()
        .GetValue(i => i.itemDefinition.description == selectedSlot.content.itemDefinition.description).sprite;
  }
}
