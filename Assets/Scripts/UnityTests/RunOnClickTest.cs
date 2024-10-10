using System;
using System.Collections;
using UnityEngine;

public class RunOnClickTest : MonoBehaviour
{
    public SceneModel sceneModel;

    void Start(){
        sceneModel = GetComponent<ObjectMonoBehaviour<SceneModel>>().GetModel();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            sceneModel.ChangeScene(SceneInstance.Field);
        }
        if(Input.GetMouseButtonDown(0)){
            sceneModel.ChangeScene(SceneInstance.Farm);
        }
    }

}
