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
        context.Subscribe<OnEveryTenMinutesChange>(OnEveryTenMinutesChangeEventHandler);
        context.Subscribe<OnStart>(OnEveryTenMinutesChangeEventHandler);
    }

    public void Disable()
    {
        context.Unsubscribe<OnEveryTenMinutesChange>(OnEveryTenMinutesChangeEventHandler);
        context.Unsubscribe<OnStart>(OnEveryTenMinutesChangeEventHandler);
    }


    private void OnEveryTenMinutesChangeEventHandler(OnEveryTenMinutesChange eventArgs)
    {
        var gameTime = eventArgs.Value;
        var viewModel = new GameTime12HoursSystemViewModel(gameTime);
        view.SetHourText(viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix);
        view.SetDayText($"Day: {viewModel.day}");
        view.SetSeasonText(viewModel.season);
        view.SetYearText($"Year: {viewModel.year}");
    }

    private void OnEveryTenMinutesChangeEventHandler(OnStart eventArgs)
    {
        var gameTime = eventArgs.Value;
        var viewModel = new GameTime12HoursSystemViewModel(gameTime);
        view.SetHourText(viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix);
        view.SetDayText($"Day: {viewModel.day}");
        view.SetSeasonText(viewModel.season);
        view.SetYearText($"Year: {viewModel.year}");
    }
}
