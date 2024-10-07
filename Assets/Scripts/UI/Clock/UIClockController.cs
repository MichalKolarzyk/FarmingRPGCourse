using System;

public class UIClockController
{
    private readonly GameTimeModel model;
    private readonly UIClockView view;

    public UIClockController(GameTimeModel model, UIClockView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Enable()
    {
        model.OnEveryTenMinutesChange += OnEveryTenMinutesChangeEventHandler;
    }

    public void Disable()
    {
        model.OnEveryTenMinutesChange -= OnEveryTenMinutesChangeEventHandler;
    }


    private void OnEveryTenMinutesChangeEventHandler(object sender, EventArgs e)
    {
        var gameTimeModel = sender as GameTimeModel;
        var viewModel = new GameTime12HoursSystemViewModel(gameTimeModel);
        view.SetHourText(viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix);
        view.SetDayText($"Day: {viewModel.day}");
        view.SetSeasonText(viewModel.season);
        view.SetYearText($"Year: {viewModel.year}");
    }
}
