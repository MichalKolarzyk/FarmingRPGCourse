using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public MovementEventArgs movementEventArgs;

    void Update(){
        EventHandler.CallMovementEvent(movementEventArgs);
    }
}
