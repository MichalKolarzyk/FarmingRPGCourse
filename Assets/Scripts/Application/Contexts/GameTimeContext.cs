using System.Collections;
using UnityEngine;

public class GameTimeContext : Context<GameTime>
{
    private bool isWaiting = false;

    public override void Set(ref GameTime model)
    {
        model ??= new GameTime(1, 1, 9, 30);
        this.model = model;
        this.model.OnDomainEvent += eventBus.Publish;
        this.model.Start();
    }

    void OnDisable(){
        model.OnDomainEvent -= eventBus.Publish;
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

        Model().NextMinute();
    }
}
