using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTeleportBehaviour : MonoBehaviour
{
    public SceneSpawnPointInfo toSpawnPoint;
    CurrentSceneContext currentSceneContext;
    void Awake(){
        currentSceneContext = FindObjectOfType<CurrentSceneContext>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(!collider2D.TryGetComponent<SceneTeleportBehaviourTrigger>(out var trigger))
            return;

        var model = currentSceneContext.Model();
        model.ChangeScene(toSpawnPoint.definition.sceneInstance);
        trigger.SetSpawnPoint(toSpawnPoint.definition.GetPositoin());
    }
}
