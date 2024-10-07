using UnityEngine.UIElements;

public class UIClockView 
{
    public UIDocument uIDocument;
    private Label seasonLabel;
    private Label yearLabel;
    private Label dayLabel;
    private Label hourLabel;


    public UIClockView(VisualElement visualElement)
    {
        seasonLabel = visualElement.Q<Label>("SeasonText");
        yearLabel = visualElement.Q<Label>("YearText");
        dayLabel = visualElement.Q<Label>("MonthText");
        hourLabel = visualElement.Q<Label>("HourText");
    }

    public void SetSeasonText(string value) => seasonLabel.text = value;
    public void SetYearText(string value) => yearLabel.text = value;
    public void SetDayText(string value) => dayLabel.text = value;
    public void SetHourText(string value) => hourLabel.text = value;
}
