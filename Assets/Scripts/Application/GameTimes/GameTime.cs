using System.Collections;
using UnityEngine;

public class GameTime : ObjectMonoBehaviour<GameTimeModel>
{
    private bool isWaiting = false;

    protected override GameTimeModel InitModelValue()
    {
        return new GameTimeModel(1, 31, 6, 30);
    }

    void Start(){
        GetModel().Activate();
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
