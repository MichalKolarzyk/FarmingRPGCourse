using System.Collections;
using UnityEngine;


public class SceneTeleportBehaviourTrigger : MonoBehaviour
{
  CurrentSceneContext sceneObjectMonoBehaviour;
  void OnEnable()
  {
    sceneObjectMonoBehaviour = FindObjectOfType<CurrentSceneContext>();
    sceneObjectMonoBehaviour.OnAfterLoadNewScene += OnAfterLoadNewSceneHandler;
  }

  void OnDisable()
  {
    sceneObjectMonoBehaviour.OnAfterLoadNewScene -= OnAfterLoadNewSceneHandler;
  }

  private IEnumerator OnAfterLoadNewSceneHandler(OnSceneChange eventArgs)
  {
    gameObject.transform.position = new Vector3(eventArgs.newSpawnPoint.positionX, eventArgs.newSpawnPoint.positionY, gameObject.transform.position.z);
    yield return new WaitForSeconds(0.5f);
  }
}
