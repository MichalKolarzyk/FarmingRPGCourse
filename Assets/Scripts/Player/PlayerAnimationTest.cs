using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public MovementEventArgs movementEventArgs;

    void Update(){
        EventHandler.CallMovementEvent(movementEventArgs);
    }
}
