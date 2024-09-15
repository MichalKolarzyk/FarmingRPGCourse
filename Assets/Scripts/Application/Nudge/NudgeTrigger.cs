using System;
using System.Collections;
using UnityEngine;

public class NudgeTrigger : MonoBehaviour
{
    public int maxRotateDegrees = 10;

    private WaitForSeconds pause;
    private bool isAnimating = false;
    private float frameRotation;


    void Awake()
    {
        pause = new WaitForSeconds(0.04f);
        frameRotation = (float)maxRotateDegrees/5;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (maxRotateDegrees == 0 || isAnimating)
            return;

        isAnimating = true;
        var isColliderOnTheLeftSide = gameObject.transform.position.x < collider2D.gameObject.transform.position.x;

        if (isColliderOnTheLeftSide)
        {
            StartCoroutine(RotateAntiClock());
        }
        else
        {
            StartCoroutine(RotateClock());
        }

        isAnimating = false;
    }

    private IEnumerator RotateAntiClock()
    {
        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.Rotate(0, 0, frameRotation);
            yield return pause;
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.Rotate(0, 0, -frameRotation);
            yield return pause;
        }

        gameObject.transform.Rotate(0, 0, frameRotation);
        yield return pause;
        yield return new WaitForSeconds(0.3f);
    }

    private IEnumerator RotateClock()
    {
        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.Rotate(0, 0, -frameRotation);
            yield return pause;
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.Rotate(0, 0, frameRotation);
            yield return pause;
        }

        gameObject.transform.Rotate(0, 0, -frameRotation);
        yield return pause;
        yield return new WaitForSeconds(0.3f);
    }
}
