using System;

public class UIClockController
{
    private readonly Context<GameTime> context;
    private readonly UIClockView view;

    public UIClockController(Context<GameTime> context, UIClockView view)
    {
        this.context = context;
        this.view = view;
    }

    public void Enable()
    {
        context.Subscribe<GameTime.OnEveryTenMinutesChange>(OnEveryTenMinutesChangeEventHandler);
        context.Subscribe<GameTime.OnStart>(OnStartEventHandler);
    }

    public void Disable()
    {
        context.Unsubscribe<GameTime.OnEveryTenMinutesChange>(OnEveryTenMinutesChangeEventHandler);
        context.Unsubscribe<GameTime.OnStart>(OnStartEventHandler);
    }


    private void OnEveryTenMinutesChangeEventHandler(GameTime.OnEveryTenMinutesChange domainEvent)
    {
        var gameTime = domainEvent.gameTime;
        var viewModel = new GameTime12HoursSystemViewModel(gameTime);
        view.SetHourText(viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix);
        view.SetDayText($"Day: {viewModel.day}");
        view.SetSeasonText(viewModel.season);
        view.SetYearText($"Year: {viewModel.year}");
    }

    private void OnStartEventHandler(GameTime.OnStart domainEvent)
    {
        var gameTime = domainEvent.gameTime;
        var viewModel = new GameTime12HoursSystemViewModel(gameTime);
        view.SetHourText(viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix);
        view.SetDayText($"Day: {viewModel.day}");
        view.SetSeasonText(viewModel.season);
        view.SetYearText($"Year: {viewModel.year}");
    }
}
