using UnityEngine;

public class ChangeSceneAction : MonoBehaviour{
  private PlayerPositionContext playerPositionContext;
  private CurrentSceneContext currentSceneContext;

  void Awake(){
    playerPositionContext = GetComponent<PlayerPositionContext>();
    currentSceneContext = GetComponent<CurrentSceneContext>();
  }

  public void Execute(){
    
  }
}