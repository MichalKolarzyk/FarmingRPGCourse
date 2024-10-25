using System;
using System.Collections;
using UnityEngine;


public class SceneTeleportBehaviourTrigger : MonoBehaviour
{
  CurrentSceneContext sceneObjectMonoBehaviour;
  Position spawnPoint;
  void OnEnable()
  {
    sceneObjectMonoBehaviour = FindObjectOfType<CurrentSceneContext>();
    sceneObjectMonoBehaviour.OnAfterLoadNewScene += OnAfterLoadNewSceneHandler;
  }

  void OnDisable()
  {
    sceneObjectMonoBehaviour.OnAfterLoadNewScene -= OnAfterLoadNewSceneHandler;
  }

  public void SetSpawnPoint(Position newSpawnPoint){
    spawnPoint = newSpawnPoint;
  }

  private IEnumerator OnAfterLoadNewSceneHandler(OnSceneChange change)
  {
    if(spawnPoint != null){
      gameObject.transform.position = spawnPoint.ToVector3();
    }
    spawnPoint = null;
    yield return new WaitForSeconds(0.5f);
  }
}
