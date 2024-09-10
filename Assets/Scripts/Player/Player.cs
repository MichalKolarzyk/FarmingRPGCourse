using UnityEngine;

public class Player : MonoBehaviour
{
  Rigidbody2D rigidBody2D;
  Direction playerDirection;
  MovementEventArgs input;
  private float movementSpeed;
  private bool PlayerInputIsDisabled { get; set; }

  void Awake()
  {
    rigidBody2D = GetComponent<Rigidbody2D>();
  }


  void Update()
  {
    UpdatePlayerInput();

    EventHandler.CallMovementEvent(input);
  }

  void FixedUpdate(){
    if(input == null) return;

    var move = new Vector2(input.inputX * movementSpeed * Time.deltaTime, input.inputY * movementSpeed * Time.deltaTime);
    rigidBody2D.MovePosition(rigidBody2D.position + move);
  }

  void UpdatePlayerInput()
  {
    input = new()
    {
      inputX = Input.GetAxisRaw("Horizontal"),
      inputY = Input.GetAxisRaw("Vertical")
    };

    if (input.inputX != 0 && input.inputY != 0)
    {
      input.inputX *= 0.71f;
      input.inputY *= 0.71f;
    }

    if (input.inputX < 0) playerDirection = Direction.left;
    else if (input.inputX > 0) playerDirection = Direction.right;
    else if (input.inputY < 0) playerDirection = Direction.down;
    else if (input.inputY > 0) playerDirection = Direction.up;
    else
    {
      playerDirection = Direction.none;
      input.isIdle = true;
    }


    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
    {
      input.isWalking = true;
      movementSpeed = Settings.playerMovement.walkingSpped;
    }
    else
    {
      input.isRunning = true;
      movementSpeed = Settings.playerMovement.runnintSpeed;
    }
  }
}
