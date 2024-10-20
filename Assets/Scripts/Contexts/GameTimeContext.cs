using System.Collections;
using UnityEngine;

public class GameTimeContext : Context<GameTime>
{
    private bool isWaiting = false;

    void Awake()
    {
        var repository = FindAnyObjectByType<Repository>();
        repository.Data.gameTime ??= new GameTime(1, 1, 9, 30);
        model = repository.Data.gameTime;
    }

    void Start()
    {
        model.Start();
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

        Get().NextMinute();
    }
}
