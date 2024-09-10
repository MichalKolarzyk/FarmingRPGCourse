public static class Settings
{
    public static PlayerMovementSettings playerMovement = new();
    public static ObscuringItemFading obscuringItemFading = new();
    public static Tags Tags = new();
}

public class Tags{
    public string BoundsConfiner = "BoundsConfiner";
    public string Player = "Player";
}

public class PlayerMovementSettings{
    public float runnintSpeed = 5.333f;
    public float walkingSpped = 2.666f;
}


public class ObscuringItemFading{
    public float fadeInSeconds = 0.25f;
    public float fadeOutSeconds = 0.35f;
    public float targetAlpha = 0.45f;
}