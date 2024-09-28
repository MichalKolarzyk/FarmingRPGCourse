using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShapeBehaviour : MonoBehaviour
{
    private PolygonCollider2D polygonCollider2D;
    private CinemachineConfiner2D cinemachineConfiner2d;
    void Start(){
        var boundsConfier = GameObject.FindGameObjectWithTag(Settings.tags.BoundsConfiner);
        polygonCollider2D = boundsConfier.GetComponent<PolygonCollider2D>();
        cinemachineConfiner2d = GetComponent<CinemachineConfiner2D>();

        cinemachineConfiner2d.m_BoundingShape2D = polygonCollider2D;
        cinemachineConfiner2d.InvalidateCache();
    }
}
