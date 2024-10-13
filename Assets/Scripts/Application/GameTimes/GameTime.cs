using System.Collections;
using UnityEngine;

public class GameTime : ObjectMonoBehaviour<GameTimeModel>
{
    private bool isWaiting = false;
    protected override GameTimeModel InitDefaultModel()
    {
        var saveModel = FindAnyObjectByType<SaveObjectMonoBehaviour>().GetModel();
        saveModel.gameTimeModel ??= new GameTimeModel(1, 31, 6, 30);
        return saveModel.gameTimeModel;
    }


    void Start()
    {
        GetModel().Start();
    }

    void Update()
    {
        if (isWaiting == true)
            return;

        StartCoroutine(WaitForNextMinute());
    }

    private IEnumerator WaitForNextMinute()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1);
        isWaiting = false;

        GetModel().NextMinute();
    }
}
