using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime12HoursSystemViewModel
{
    public readonly string hoursAndMinutes;
    public readonly string hoursAndMinutesPrefix;
    public readonly string day;
    public readonly string year;
    public readonly string season;
    
    public GameTime12HoursSystemViewModel(GameTimeModel model)
    {
        hoursAndMinutes = $"{GetHours(model)}:{GetMinutes(model)}";
        hoursAndMinutesPrefix = model.GetHours() < 12 ? "PM" : "AM";
        day = model.GetDay().ToString();
        year = model.GetYear().ToString();
        season = model.GetSeason().ToString();
    }

    private string GetHours(GameTimeModel model)
    {
        return AddZeroPrefix(model.GetHours() % 12);
    }

    private string GetMinutes(GameTimeModel model){
        return AddZeroPrefix(model.GetMinutes());
    }

    private string GetHoursAndMinutesSuffix(GameTimeModel model)
    {
        var hours = model.GetHours();
        if(hours < 12)
            return "AM";

        else return "PM";
    }

    private string AddZeroPrefix(int value)
    {
        return value >= 10 ? value.ToString() : $"0{value}";
    }
}
