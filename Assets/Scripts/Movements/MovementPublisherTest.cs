using UnityEngine;

public class MovementPublisherTest : MonoBehaviour
{
    public MovementModel playerMovementModel;

    public MovementPublisher playerMovementPublisher;
    void Start(){
        playerMovementPublisher = GetComponent<MovementPublisher>();
    }

    void Update(){
        playerMovementPublisher.Publish(playerMovementModel);
    }
}
