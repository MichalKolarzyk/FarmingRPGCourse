using Cinemachine;
using UnityEngine;

public class MainCameraService : IService
{
    readonly Camera mainCamera;
    public MainCameraService(){
        mainCamera = Camera.main;
    }


    public Vector3 GetFollowViewport(ICinemachineCamera cinemachineCamera){
        return mainCamera.WorldToViewportPoint(cinemachineCamera.Follow.position);
    }

    public Vector3 GetWordMousePosition(){
        return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
    }
}
