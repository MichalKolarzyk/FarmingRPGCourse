public class HumanMovement : ObjectMonoBehaviour<MovementModel>
{
    protected override MovementModel InitModelValue()
    {
        var definition = new MovementDefinition(Settings.playerMovement.walkingSpeed, Settings.playerMovement.runnintSpeed);
        return new MovementModel(definition);
    }
}
