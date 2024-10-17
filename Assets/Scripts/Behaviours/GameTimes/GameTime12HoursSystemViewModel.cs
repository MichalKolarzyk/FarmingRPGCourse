public class GameTime12HoursSystemViewModel
{
    public readonly string hoursAndMinutes;
    public readonly string hoursAndMinutesPrefix;
    public readonly string day;
    public readonly string year;
    public readonly string season;
    
    public GameTime12HoursSystemViewModel(GameTime model)
    {
        hoursAndMinutes = $"{GetHours(model)}:{GetMinutes(model)}";
        hoursAndMinutesPrefix = model.GetHours() < 12 ? "PM" : "AM";
        day = model.GetDay().ToString();
        year = model.GetYear().ToString();
        season = model.GetSeason().ToString();
    }

    private string GetHours(GameTime model)
    {
        return AddZeroPrefix(model.GetHours() % 12);
    }

    private string GetMinutes(GameTime model){
        return AddZeroPrefix(model.GetMinutes());
    }

    private string AddZeroPrefix(int value)
    {
        return value >= 10 ? value.ToString() : $"0{value}";
    }
}
