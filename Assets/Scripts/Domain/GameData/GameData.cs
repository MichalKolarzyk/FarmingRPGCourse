using System;

[Serializable]
public class GameData : Entity{
  public GameTime gameTime;
  public CurrentScene currentScene;
  public Inventory playerInventory;
  public Movement playerMovement;
  public Position playerPosition;
}
