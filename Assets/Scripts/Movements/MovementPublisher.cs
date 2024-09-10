using System;
using UnityEngine;

public class MovementPublisher : MonoBehaviour
{
  public event EventHandler<MovementModel> OnMovementEvent;
  public void Publish(MovementModel playerMovementModel){
    OnMovementEvent?.Invoke(this, playerMovementModel);
  }
}
