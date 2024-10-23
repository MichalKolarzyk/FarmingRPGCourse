using System;
using System.Collections.Generic;
[Serializable]
public class CurrentScene: Entity
{
    public SceneSpawnPointDefinition spawnPoint = new();
    public List<SceneData> sceneDatas = new();
    public CurrentScene(SceneSpawnPointDefinition sceneSpawnPointDefinition) {
        spawnPoint = sceneSpawnPointDefinition;
    }

    public void ChangeScene(SceneSpawnPointDefinition newSpawnPoint)
    {
        AddEvent(new OnSceneChange(newSpawnPoint, spawnPoint.sceneInstance));
        spawnPoint = newSpawnPoint;
    }

    public void Start(){
        AddEvent(new OnSceneChange(spawnPoint, SceneInstance.None));
    }

    public SceneData GetSceneData(){
        var sceneData =  sceneDatas.Find(s => s.sceneInstance == spawnPoint.sceneInstance);
        if(sceneData == null){
            sceneData = new SceneData(spawnPoint.sceneInstance);
            sceneDatas.Add(sceneData);
        }
        return sceneData;
    }
}