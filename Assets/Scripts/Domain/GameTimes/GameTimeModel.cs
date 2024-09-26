using System;

public class GameTimeModel
{
    public event EventHandler OnSeasonChange;
    public event EventHandler OnYearChange;
    public event EventHandler OnMinuteChange;
    public event EventHandler OnEveryTenMinutesChange;

    private DateTime now;
    private bool isActivated = false;
    private bool isPaused = false;
    private static readonly int startYear = 2000;
    public GameTimeModel(int hour, int minute)
    {
        this.now = new DateTime(startYear, 1, 1, hour, minute, 0);
    }

    public void NextMinute()
    {
        if (isActivated == false)
            throw new Exception("Game time is inactive you need to activate it first");

        if (isPaused)
            return;

        var previousDateTime = now;
        now = now.AddMinutes(1);
        CallEvents(previousDateTime, now);
    }

    public int GetHour()
    {
        return now.Hour;
    }

    public int GetMinute()
    {
        return now.Minute;
    }

    public int GetYear()
    {
        return now.Year - (startYear + 1);
    }

    public Season GetSeason()
    {
        return GetSeason(now);
    }

    public string ToHourAndMinutes()
    {
        return $"{GetHour()}:{GetMinute()}";
    }

    public void Activate()
    {
        if (isActivated == true)
            throw new Exception("Game time is already active");

        isActivated = true;
        CallEvents(now.AddMinutes(-1), now);
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Unpause()
    {
        isPaused = false;
    }

    private Season GetSeason(DateTime dateTime)
    {
        var currentMonth = dateTime.Month;
        if (currentMonth >= 2 && currentMonth < 5) return Season.Spring;
        if (currentMonth >= 5 && currentMonth < 8) return Season.Summer;
        if (currentMonth >= 8 && currentMonth < 11) return Season.Autumn;
        return Season.Winter;
    }

    private void CallEvents(DateTime previous, DateTime current)
    {
        OnMinuteChange?.Invoke(this, EventArgs.Empty);
        if (GetMinute() % 10 == 0) OnEveryTenMinutesChange?.Invoke(this, EventArgs.Empty);
        if (GetSeason(previous) != GetSeason(current)) OnSeasonChange?.Invoke(this, EventArgs.Empty);
        if (previous.Year != current.Year) OnYearChange?.Invoke(this, EventArgs.Empty);
    }
}

public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter,
}