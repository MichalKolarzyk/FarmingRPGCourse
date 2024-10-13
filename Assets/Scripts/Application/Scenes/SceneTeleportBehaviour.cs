using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTeleportBehaviour : MonoBehaviour
{
    public SceneSpawnPointInfo toSpawnPoint;
    Scene sceneObjectMonoBehaviour;
    void Awake(){
        sceneObjectMonoBehaviour = FindObjectOfType<Scene>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var isTrigger = collider2D.TryGetComponent(out SceneTeleportBehaviourTrigger trigger);
        if(!isTrigger)
            return;

        var model = sceneObjectMonoBehaviour.GetModel();
        model.ChangeScene(toSpawnPoint.definition);
    }
}
