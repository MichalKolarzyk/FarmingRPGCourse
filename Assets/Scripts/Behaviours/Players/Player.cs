using UnityEngine;

[RequireComponent(typeof(Context<Movement>))]
[RequireComponent(typeof(Context<Inventory>))]
public class Player : MonoBehaviour
{
  Rigidbody2D rigidBody2D;
  Movement movementModel;
  Inventory inventoryModel;

  void Awake()
  {
    rigidBody2D = GetComponent<Rigidbody2D>();
  }

  void Start()
  {
    movementModel = GetComponent<Context<Movement>>().Get();
    inventoryModel = GetComponent<Context<Inventory>>().Get();
  }


  void Update()
  {
    var inputX = Input.GetAxisRaw("Horizontal");
    var inputY = Input.GetAxisRaw("Vertical");
    var isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    var selectedSlot = inventoryModel.GetSelectedSlot();
    var isCarrying = selectedSlot != null && selectedSlot.content.itemDefinition.canBeCarried;

    movementModel.UpdateMovement(inputX, inputY, isWalking, isCarrying);
  }

  void FixedUpdate()
  {
    if (movementModel == null) return;
    rigidBody2D.MovePosition(rigidBody2D.position + movementModel.GetMovement());
  }
}
