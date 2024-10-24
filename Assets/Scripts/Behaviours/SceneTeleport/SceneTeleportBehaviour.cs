using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTeleportBehaviour : MonoBehaviour
{
    public SceneSpawnPointInfo toSpawnPoint;
    CurrentSceneContext sceneObjectMonoBehaviour;
    void Awake(){
        sceneObjectMonoBehaviour = FindObjectOfType<CurrentSceneContext>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var isTrigger = collider2D.TryGetComponent(out SceneTeleportBehaviourTrigger trigger);
        if(!isTrigger)
            return;

        var model = sceneObjectMonoBehaviour.Model();
        model.ChangeScene(toSpawnPoint.definition);
    }
}
