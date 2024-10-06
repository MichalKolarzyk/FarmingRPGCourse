using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIClock : MonoBehaviour
{
    public ObjectMonoBehaviour<GameTimeModel> gameTime;
    private GameTimeModel model;
    private UIClockView view;

    void Awake()
    {
        var uiDocument = GetComponent<UIDocument>();
        var clockVisualElement = uiDocument.rootVisualElement.Q("ClockView");
        view = new UIClockView(clockVisualElement);
    }

    void OnEnable()
    {
        model = gameTime.GetModel();
        model.OnEveryTenMinutesChange += OnEveryTenMinutesChangeEventHandler;
    }

    void OnDisable()
    {
        model.OnEveryTenMinutesChange -= OnEveryTenMinutesChangeEventHandler;
    }


    private void OnEveryTenMinutesChangeEventHandler(object sender, EventArgs e)
    {
        var gameTimeModel = sender as GameTimeModel;
        var viewModel = new GameTime12HoursSystemViewModel(gameTimeModel);
        view.hourLabel.text = viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix;
        view.dayLabel.text = $"Day: {viewModel.day}";
        view.seasonLabel.text = viewModel.season;
        view.yearLabel.text = $"Year: {viewModel.year}";
    }
}
