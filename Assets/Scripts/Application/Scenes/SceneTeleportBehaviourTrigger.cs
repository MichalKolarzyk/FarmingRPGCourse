using System.Collections;
using UnityEngine;


public class SceneTeleportBehaviourTrigger : MonoBehaviour
{
  Scene sceneObjectMonoBehaviour;
  void OnEnable()
  {
    sceneObjectMonoBehaviour = FindObjectOfType<Scene>();
    sceneObjectMonoBehaviour.OnAfterLoadNewScene += OnAfterLoadNewSceneHandler;
  }

  void OnDisable()
  {
    sceneObjectMonoBehaviour.OnAfterLoadNewScene -= OnAfterLoadNewSceneHandler;
  }

  private IEnumerator OnAfterLoadNewSceneHandler(ChangeSceneEventArg eventArgs)
  {
    gameObject.transform.position = new Vector3(eventArgs.newSceneSpawnPoint.positionX, eventArgs.newSceneSpawnPoint.positionY, gameObject.transform.position.z);
    yield return new WaitForSeconds(0.5f);
  }
}
