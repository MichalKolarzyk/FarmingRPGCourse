public class GameDataContext : Context<GameData>
{
  public override void Set(ref GameData model)
  {
    FindAnyObjectByType<GameTimeContext>().Set(ref model.gameTime);
    FindAnyObjectByType<PlayerPositionContext>().Set(ref model.playerPosition);
    FindAnyObjectByType<PlayerMovementContext>().Set(ref model.playerMovement);
    FindAnyObjectByType<PlayerInventoryContext>().Set(ref model.playerInventory);
    FindAnyObjectByType<CurrentSceneContext>().Set(ref model.currentScene);
  }
}
