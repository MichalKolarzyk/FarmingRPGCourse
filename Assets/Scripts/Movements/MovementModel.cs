using UnityEngine;

public class MovementModel
{
    public float inputX;
    public float inputY;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    public bool isCarrying;
    public ToolEffect toolEffect;
    public bool isUsingToolRight;
    public bool isUsingToolLeft;
    public bool isUsingToolUp;
    public bool isUsingToolDown;
    public bool isLiftingToolRight;
    public bool isLiftingToolLeft;
    public bool isLiftingToolUp;
    public bool isLiftingToolDown;
    public bool isPickingRight;
    public bool isPickingLeft;
    public bool isPickingUp;
    public bool isPickingDown;
    public bool isSwingingToolRight;
    public bool isSwingingToolLeft;
    public bool isSwingingToolUp;
    public bool isSwingingToolDown;
    public bool idleUp;
    public bool idleDown;
    public bool idleLeft;
    public bool idleRight;
    public float currentMovementSpeed;

    public MovementModel(float inputX, float inputY, bool isWalking, MovementSpeedDefinition movementSpeedDefinition)
    {
        this.inputX = inputX;
        this.inputY = inputY;

        if (inputX != 0 && inputY != 0)
        {
            this.inputX *= 0.71f;
            this.inputY *= 0.71f;
        }

        if (this.inputX == 0 && inputY == 0)
        {
            this.isIdle = true;
        }
        else if (isWalking)
        {
            this.isWalking = true;
            this.currentMovementSpeed = movementSpeedDefinition?.walkingSpeed ?? 0;
        }
        else
        {
            isRunning = true;
            this.currentMovementSpeed = movementSpeedDefinition?.runningSpeed ?? 0;
        }

    }
    public MovementModel() { }


    public Direction GetDirection()
    {
        if (inputX < 0) return Direction.left;
        else if (inputX > 0) return Direction.right;
        else if (inputY < 0) return Direction.down;
        else if (inputY > 0) return Direction.up;
        else
        {
            return Direction.none;
        }
    }

    public Vector2 GetMovement(){
        return new Vector2(inputX * currentMovementSpeed * Time.deltaTime, inputY * currentMovementSpeed * Time.deltaTime);
    }
}


public class MovementSpeedDefinition{
    public float walkingSpeed;
    public float runningSpeed;

    public MovementSpeedDefinition(float walkingSpeed, float runningSpeed)
    {
        this.walkingSpeed = walkingSpeed;
        this.runningSpeed = runningSpeed;
    }
}