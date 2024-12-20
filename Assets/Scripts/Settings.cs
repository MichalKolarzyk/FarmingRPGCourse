public static class Settings
{
    public static PlayerMovementSettings playerMovement = new();
    public static ObscuringItemFadingSettings obscuringItemFading = new();
    public static InventorySettings inventory = new();
}

public class PlayerMovementSettings{
    public float runnintSpeed = 5.333f;
    public float walkingSpeed = 2.666f;
}


public class ObscuringItemFadingSettings{
    public float fadeInSeconds = 0.25f;
    public float fadeOutSeconds = 0.35f;
    public float targetAlpha = 0.45f;
}

public class InventorySettings{
    public int playerInitialInventoryCapacity = 12;
    public int playerMaximumInventoryCapacity = 48;
}