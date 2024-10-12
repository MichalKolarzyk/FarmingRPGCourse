using System.Collections;
using UnityEngine;

public class SceneTeleportBehaviourTrigger : MonoBehaviour
{
  SceneObjectMonoBehaviour sceneObjectMonoBehaviour;
  void OnEnable()
  {
    sceneObjectMonoBehaviour = FindObjectOfType<SceneObjectMonoBehaviour>();
    sceneObjectMonoBehaviour.OnBeforeLoadNewScene += OnBeforeUnloadOldSceneHandler;
  }

  void OnDisable()
  {
    sceneObjectMonoBehaviour.OnBeforeLoadNewScene -= OnBeforeUnloadOldSceneHandler;
  }

  private IEnumerator OnBeforeUnloadOldSceneHandler(ChangeSceneEventArg eventArgs)
  {
    gameObject.transform.position = new Vector3(eventArgs.newSceneSpawnPoint.positionX, eventArgs.newSceneSpawnPoint.positionY, 0);
    yield return null;
  }
}
