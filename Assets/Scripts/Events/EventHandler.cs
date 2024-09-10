public delegate void MovementDelegate(MovementEventArgs movementEventArgs);

public static class EventHandler
{
    public static event MovementDelegate MovementEvent;
    public static void CallMovementEvent(MovementEventArgs movementEventArgs){
        MovementEvent?.Invoke(movementEventArgs);
    }
}
[System.Serializable]
public class MovementEventArgs{
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
}