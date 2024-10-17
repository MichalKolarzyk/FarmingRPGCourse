using UnityEngine;
using Cinemachine;

public class BoundsConfinerBehaviour : MonoBehaviour
{
    private PolygonCollider2D polygonCollider2D;
    private CinemachineConfiner2D cinemachineConfiner2d;
    void Start(){
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        cinemachineConfiner2d = FindAnyObjectByType<CinemachineConfiner2D>();

        cinemachineConfiner2d.m_BoundingShape2D = polygonCollider2D;
        cinemachineConfiner2d.InvalidateCache();
    }
}
