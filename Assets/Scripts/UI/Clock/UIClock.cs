using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    public ObjectMonoBehaviour<GameTimeModel> gameTime;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI seasonText;
    public TextMeshProUGUI yearText;
    private GameTimeModel model;
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
        timeText.text = viewModel.hoursAndMinutes + " " + viewModel.hoursAndMinutesPrefix;
        dateText.text = viewModel.day;
        seasonText.text = viewModel.season;
        yearText.text = viewModel.year;
    }
}
