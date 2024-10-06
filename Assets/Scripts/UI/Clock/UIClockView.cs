using UnityEngine.UIElements;

public class UIClockView 
{
    public UIDocument uIDocument;
    public Label seasonLabel;
    public Label yearLabel;
    public Label dayLabel;
    public Label hourLabel;


    public UIClockView(VisualElement visualElement)
    {
        seasonLabel = visualElement.Q<Label>("SeasonText");
        yearLabel = visualElement.Q<Label>("YearText");
        dayLabel = visualElement.Q<Label>("MonthText");
        hourLabel = visualElement.Q<Label>("HourText");
    }
}
