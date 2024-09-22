using Cinemachine;
using UnityEngine;

public class MainCameraService : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineVirtualCamera;
    Camera mainCamera;
    Transform follow;
    void Awake(){
        cinemachineVirtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        mainCamera = Camera.main;
    }

    void Start(){
        follow = cinemachineVirtualCamera.Follow;
    }

    public Vector3 GetFollowViewport(){
        return mainCamera.WorldToViewportPoint(follow.position);
    }

    public Vector3 GetWordMousePosition(){
        return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
    }
}
