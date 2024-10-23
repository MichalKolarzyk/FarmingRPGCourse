public class OnMinuteChange : DomainEvent<GameTime>
{
  public OnMinuteChange(GameTime value) : base(value)
  {
  }
}

public class OnEveryTenMinutesChange : DomainEvent<GameTime>
{
  public OnEveryTenMinutesChange(GameTime value) : base(value)
  {
  }
}

public class OnStart : DomainEvent<GameTime>
{
  public OnStart(GameTime value) : base(value)
  {
  }
}

public class OnSeasonChange : DomainEvent<GameTime>
{
  public OnSeasonChange(GameTime value) : base(value)
  {
  }
}

public class OnYearChange : DomainEvent<GameTime>
{
  public OnYearChange(GameTime value) : base(value)
  {
  }
}