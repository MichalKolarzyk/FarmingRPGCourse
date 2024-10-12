using System;
using System.Collections;
using UnityEngine;

public class RunOnClickTest : MonoBehaviour
{
    public SceneModel sceneModel;

    void Start()
    {
        sceneModel = GetComponent<ObjectMonoBehaviour<SceneModel>>().GetModel();
    }


    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.L))
    //     {
    //         sceneModel.ChangeScene(SceneInstance.Farm);
    //     }
    //     if (Input.GetKeyDown(KeyCode.N))
    //     {
    //         sceneModel.ChangeScene(SceneInstance.Field);
    //     }
    // }

}
