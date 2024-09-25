using UnityEngine;

[RequireComponent(typeof(ObjectMonoBehaviour<MovementModel>))]
[RequireComponent(typeof(ObjectMonoBehaviour<InventoryModel>))]
public class Player : MonoBehaviour
{
  Rigidbody2D rigidBody2D;
  MovementModel movementModel;
  InventoryModel inventoryModel;

  void Awake()
  {
    movementModel = GetComponent<ObjectMonoBehaviour<MovementModel>>().GetModel();
    inventoryModel = GetComponent<ObjectMonoBehaviour<InventoryModel>>().GetModel();
    rigidBody2D = GetComponent<Rigidbody2D>();
  }


  void Update()
  {
    var inputX = Input.GetAxisRaw("Horizontal");
    var inputY = Input.GetAxisRaw("Vertical");
    var isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    var isCarrying = inventoryModel.GetSelectedSlot() != null;

    movementModel.UpdateMovement(inputX, inputY, isWalking, isCarrying);
  }

  void FixedUpdate()
  {
    if (movementModel == null) return;
    rigidBody2D.MovePosition(rigidBody2D.position + movementModel.GetMovement());
  }
}
