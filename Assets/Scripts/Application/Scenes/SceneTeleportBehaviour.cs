using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class SceneTeleportBehaviour : MonoBehaviour
{
    public Vector2 spawnPoint;
    public SceneInstance toScene;
    SceneObjectMonoBehaviour sceneObjectMonoBehaviour;
    void Awake(){
        sceneObjectMonoBehaviour = MonoBehaviourContainer.Instance.Get<SceneObjectMonoBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var isPlayer = collider2D.TryGetComponent<Player>(out Player player);
        if(!isPlayer)
            return;

        var model = sceneObjectMonoBehaviour.GetModel();
        model.ChangeScene(toScene);
    }
}
