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
        context.Get().OnEveryTenMinutesChange += OnEveryTenMinutesChangeEventHandler;
        context.Get().OnStart += OnEveryTenMinutesChangeEventHandler;
    }

    public void Disable()
    {
        context.Get().OnEveryTenMinutesChange -= OnEveryTenMinutesChangeEventHandler;
        context.Get().OnStart -= OnEveryTenMinutesChangeEventHandler;
    }


    private void OnEveryTenMinutesChangeEventHandler(GameTime gameTime)
    {
        var viewModel = new GameTime12HoursSystemViewModel(gameTime);
        view.SetHourText(viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix);
        view.SetDayText($"Day: {viewModel.day}");
        view.SetSeasonText(viewModel.season);
        view.SetYearText($"Year: {viewModel.year}");
    }
}
