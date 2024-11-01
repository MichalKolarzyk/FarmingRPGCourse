using System;
using System.Collections.Generic;
[Serializable]
public class CurrentScene: Entity
{
    public SceneInstance sceneInstance;
    public List<SceneData> sceneDatas = new();
    public CurrentScene(SceneInstance sceneInstance) {
        this.sceneInstance = sceneInstance;
    }

    public void ChangeScene(SceneInstance newSceneInstance)
    {
        AddEvent(new OnSceneChange(sceneInstance, newSceneInstance));
        sceneInstance = newSceneInstance;
    }

    public void Start(){
        AddEvent(new OnSceneChange(SceneInstance.PersistentScene, sceneInstance));
    }

    public SceneData GetSceneData(){
        var sceneData =  sceneDatas.Find(s => s.sceneInstance == sceneInstance);
        if(sceneData == null){
            sceneData = new SceneData(sceneInstance);
            sceneDatas.Add(sceneData);
        }
        return sceneData;
    }
}