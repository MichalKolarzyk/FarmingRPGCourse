
using UnityEngine;

public class TriggerObscuringScenaryFader : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obscuriongScenaryFaders = collision.GetComponentsInChildren<ObscuriongScenaryFader>();
        foreach (var obscuriongScenaryFader in obscuriongScenaryFaders)
        {
            obscuriongScenaryFader.FadeOut();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        var obscuriongScenaryFaders = collision.GetComponentsInChildren<ObscuriongScenaryFader>();
        foreach (var obscuriongScenaryFader in obscuriongScenaryFaders)
        {
            obscuriongScenaryFader.FadeIn();
        }
    }
}
