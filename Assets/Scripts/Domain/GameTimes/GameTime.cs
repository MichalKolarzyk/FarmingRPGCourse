using System;

[Serializable]
public class GameTime
{
    public bool isPaused = false;
    public long ticks = 0;
    private const int hourTicks = 60;
    private const int dayTicks = hourTicks * 24;
    private const int seasonTicks = dayTicks * 30;
    private const int yearTicks = dayTicks * 120;

    public event Action<GameTime> OnMinuteChange;
    public event Action<GameTime> OnEveryTenMinutesChange;
    public event Action<GameTime> OnStart;
    public event Action<GameTime> OnSeasonChange;
    public event Action<GameTime> OnYearChange;
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
        OnStart?.Invoke(this);
    }


    private void CallEvents()
    {
        OnMinuteChange?.Invoke(this);
        if (ticks % 10 == 0) OnEveryTenMinutesChange?.Invoke(this);
        if (ticks % seasonTicks == 0) OnSeasonChange?.Invoke(this);
        if (ticks % yearTicks == 0) OnYearChange?.Invoke(this);
    }

    private string AddZeroPrefix(int value)
    {
        return value < 10 ? value.ToString() : $"0{value}";
    }
}

public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter,
}