using UnityEngine;

public class Player : MonoBehaviour
{
  Rigidbody2D rigidBody2D;
  MovementModel input;
  MovementPublisher playerMovementPublisher;
  MovementSpeedDefinition movementSpeedDefinition;
  private bool PlayerInputIsDisabled { get; set; }

  void Awake()
  {
    rigidBody2D = GetComponent<Rigidbody2D>();
    playerMovementPublisher = GetComponent<MovementPublisher>();
    movementSpeedDefinition = new MovementSpeedDefinition(Settings.playerMovement.walkingSpeed, Settings.playerMovement.runnintSpeed);
  }


  void Update()
  {
    var inputX = Input.GetAxisRaw("Horizontal");
    var inputY = Input.GetAxisRaw("Vertical");
    var isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

    input = new(inputX, inputY, isWalking, movementSpeedDefinition);
    playerMovementPublisher.Publish(input);
  }

  void FixedUpdate(){
    if(input == null) return;
    rigidBody2D.MovePosition(rigidBody2D.position + input.GetMovement());
  }
}
