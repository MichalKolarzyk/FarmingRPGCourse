
using UnityEngine;

public class ObscuringFaderBehaviourTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obscuriongScenaryFaders = collision.GetComponentsInChildren<ObscuringFaderBehaviour>();
        foreach (var obscuriongScenaryFader in obscuriongScenaryFaders)
        {
            obscuriongScenaryFader.FadeOut();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        var obscuriongScenaryFaders = collision.GetComponentsInChildren<ObscuringFaderBehaviour>();
        foreach (var obscuriongScenaryFader in obscuriongScenaryFaders)
        {
            obscuriongScenaryFader.FadeIn();
        }
    }
}
