using Cinemachine;
using UnityEngine;

public class MainCameraService : IService
{
    CinemachineVirtualCamera cinemachineVirtualCamera;
    Camera mainCamera;
    public MainCameraService(){
        cinemachineVirtualCamera = GameObject.FindAnyObjectByType<CinemachineVirtualCamera>();
        mainCamera = Camera.main;
    }


    public Vector3 GetFollowViewport(){
        return mainCamera.WorldToViewportPoint(cinemachineVirtualCamera.Follow.position);
    }

    public Vector3 GetWordMousePosition(){
        return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
    }
}
