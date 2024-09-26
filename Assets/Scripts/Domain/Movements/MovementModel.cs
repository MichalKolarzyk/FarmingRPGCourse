using System;
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

    public event EventHandler OnMoveUpdateEvent;
    public event EventHandler<bool> OnIsCarryingItemChangeEvent;

    private readonly MovementDefinition movementDefinition;

    public MovementModel(MovementDefinition movementDefinition) 
    { 
        this.movementDefinition = movementDefinition;
    }


    private Direction GetDirection()
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

    public Vector2 GetMovement()
    {
        return new Vector2(inputX * currentMovementSpeed * Time.deltaTime, inputY * currentMovementSpeed * Time.deltaTime);
    }

    public void UpdateMovement(float inputX, float inputY, bool isWalking, bool isCarrying){
        Restart();
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
            this.currentMovementSpeed = movementDefinition?.walkingSpeed ?? 0;
        }
        else
        {
            isRunning = true;
            this.currentMovementSpeed = movementDefinition?.runningSpeed ?? 0;
        }
        SetIsCarrying(isCarrying);
        OnMoveUpdateEvent?.Invoke(this, EventArgs.Empty);
    }

    private void SetIsCarrying(bool isCarrying){
        if(this.isCarrying == isCarrying)
            return;

        this.isCarrying = isCarrying;
        OnIsCarryingItemChangeEvent(this, isCarrying);
    }

    private void Restart()
    {
        inputX = 0;
        inputY = 0;
        isWalking = false;
        isRunning = false;
        isIdle = true;
        //isCarrying = false;
        toolEffect = ToolEffect.none;
        // bool isUsingToolRight;
        // bool isUsingToolLeft;
        // bool isUsingToolUp;
        // bool isUsingToolDown;
        // bool isLiftingToolRight;
        // bool isLiftingToolLeft;
        // bool isLiftingToolUp;
        // bool isLiftingToolDown;
        // bool isPickingRight;
        // bool isPickingLeft;
        // bool isPickingUp;
        // bool isPickingDown;
        // bool isSwingingToolRight;
        // bool isSwingingToolLeft;
        // bool isSwingingToolUp;
        // bool isSwingingToolDown;
        // bool idleUp;
        // bool idleDown;
        // bool idleLeft;
        // bool idleRight;
        currentMovementSpeed = 0;
    }
}

public enum ToolEffect
{
    none,
    watering,
}

public enum Direction
{
    none,
    up,
    down,
    left,
    right,
}