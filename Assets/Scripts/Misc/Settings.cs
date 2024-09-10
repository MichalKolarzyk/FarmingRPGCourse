using UnityEngine;

public static class Settings
{
    public static PlayerAnimationParametersSettings PlayerAnimationParameters = new();
    public static SharedAnimationParametersSettings SharedAnimationParameters = new();
    public static PlayerMovementSettings playerMovement = new();
    public static Tags Tags = new();
}

public class Tags{
    public string BoundsConfiner = "BoundsConfiner";
}

public class PlayerMovementSettings{
    public float runnintSpeed = 5.333f;
    public float walkingSpped = 2.666f;
}

public class PlayerAnimationParametersSettings{
    public int inputX = Animator.StringToHash("xInput"); 
    public int inputY = Animator.StringToHash("yInput"); 
    public int isWalking = Animator.StringToHash("isWalking"); 
    public int isRunning = Animator.StringToHash("isRunning"); 
    public int toolEffect = Animator.StringToHash("toolEffect"); 
    public int isUsingToolRight = Animator.StringToHash("isUsingToolRight"); 
    public int isUsingToolLeft = Animator.StringToHash("isUsingToolLeft"); 
    public int isUsingToolUp = Animator.StringToHash("isUsingToolUp"); 
    public int isUsingToolDown = Animator.StringToHash("isUsingToolDown"); 
    public int isLiftingToolRight = Animator.StringToHash("isLiftingToolRight"); 
    public int isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft"); 
    public int isLiftingToolUp = Animator.StringToHash("isLiftingToolUp"); 
    public int isLiftingToolDown = Animator.StringToHash("isLiftingToolDown"); 
    public int isPickingRight = Animator.StringToHash("isPickingRight"); 
    public int isPickingLeft = Animator.StringToHash("isPickingLeft"); 
    public int isPickingUp = Animator.StringToHash("isPickingUp"); 
    public int isPickingDown = Animator.StringToHash("isPickingDown"); 
    public int isSwingingToolRight = Animator.StringToHash("isSwingingToolRight"); 
    public int isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft"); 
    public int isSwingingToolUp = Animator.StringToHash("isSwingingToolUp"); 
    public int isSwingingToolDown = Animator.StringToHash("isSwingingToolDown"); 

}

public class SharedAnimationParametersSettings{
    public int idleUp = Animator.StringToHash("idleUp"); 
    public int idleDown = Animator.StringToHash("idleDown"); 
    public int idleLeft = Animator.StringToHash("idleLeft"); 
    public int idleRight = Animator.StringToHash("idleRight"); 
}