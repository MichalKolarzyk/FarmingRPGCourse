using System;

[Serializable]
public class GameTime : Aggregate
{
    public bool isPaused = false;
    public long ticks = 0;
    private const int hourTicks = 60;
    private const int dayTicks = hourTicks * 24;
    private const int seasonTicks = dayTicks * 30;
    private const int yearTicks = dayTicks * 120;
    public GameTime(int year, int day, int hour, int minute)
    {
        ticks = year * yearTicks + day * dayTicks + hour * hourTicks + minute;
    }

    public GameTime() { }

    public void NextMinute()
    {
        if (isPaused)
            return;

        ticks += 1;
        CallEvents();
    }

    public int GetDay()
    {
        return (int)ticks % yearTicks / dayTicks;
    }

    public int GetHours()
    {
        return (int)ticks % dayTicks / hourTicks;
    }

    public int GetMinutes()
    {
        return (int)ticks % dayTicks % hourTicks;
    }

    public int GetYear()
    {
        return (int)ticks / yearTicks;
    }

    public Season GetSeason()
    {
        return (Season)(int)(ticks % yearTicks / seasonTicks);
    }

    public string ToHourAndMinutes()
    {
        return $"{AddZeroPrefix(GetHours())}:{AddZeroPrefix(GetMinutes())}";
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Start()
    {
        isPaused = false;
        AddEvent(new OnStart(this));
    }


    private void CallEvents()
    {
        AddEvent(new OnMinuteChange(this));
        if (ticks % 10 == 0) AddEvent(new OnEveryTenMinutesChange(this));
        if (ticks % seasonTicks == 0) AddEvent(new OnSeasonChange(this));
        if (ticks % yearTicks == 0) AddEvent(new OnYearChange(this));
    }

    private string AddZeroPrefix(int value)
    {
        return value < 10 ? value.ToString() : $"0{value}";
    }

    public class OnStart : DomainEvent
    {
        public GameTime gameTime;

        public OnStart(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
    }
    public class OnSeasonChange : DomainEvent
    {
        public GameTime gameTime;

        public OnSeasonChange(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
    }
    public class OnYearChange : DomainEvent
    {
        public GameTime gameTime;

        public OnYearChange(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
    }
    public class OnMinuteChange : DomainEvent
    {
        public GameTime gameTime;

        public OnMinuteChange(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
    }
    public class OnEveryTenMinutesChange : DomainEvent
    {
        public GameTime gameTime;

        public OnEveryTenMinutesChange(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
    }
}

public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter,
}