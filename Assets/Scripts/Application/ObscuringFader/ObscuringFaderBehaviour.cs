using System.Collections;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class ObscuringFaderBehaviour : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Coroutine currentCoroutine;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        if (gameObject.activeInHierarchy == false)
            return;
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        float currentAlpha = spriteRenderer.color.a;
        float targetAlpha = Settings.obscuringItemFading.targetAlpha;
        float fadeOutSeconds = Settings.obscuringItemFading.fadeOutSeconds;
        float distance = currentAlpha - targetAlpha;

        while (currentAlpha - targetAlpha > 0.01f)
        {
            currentAlpha -= distance / fadeOutSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, currentAlpha);
            yield return null;
        }

        spriteRenderer.color = new Color(1, 1, 1, targetAlpha);
    }

    public void FadeIn()
    {
        if (gameObject.activeInHierarchy == false)
            return;

        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
            
        currentCoroutine = StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
        float currentAlpha = spriteRenderer.color.a;
        float targetAlpha = 1f;
        float fadeInSeconds = Settings.obscuringItemFading.fadeInSeconds;
        float distance = targetAlpha - currentAlpha;

        while (currentAlpha <= targetAlpha)
        {
            currentAlpha += distance / fadeInSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, currentAlpha);
            yield return null;
        }

        spriteRenderer.color = new Color(1, 1, 1, targetAlpha);
    }
}
