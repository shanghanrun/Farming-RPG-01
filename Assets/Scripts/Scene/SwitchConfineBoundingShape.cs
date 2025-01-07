using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    void Start(){
        SwitchBoundingShape();
    }
    /// <summary>
    /// Switch the collider that cinemachine uses to define the edges of the screen
    /// </summary>
    void SwitchBoundingShape(){
        // 'BoundsConfiner' Tag이름의 게임오브젝트를 찾고, 그것의 컴포넌트인 polygonCollider2D얻기
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();
        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        // confiner bounds가 변했기 때문에, cache를 지우기 위해 다음을 호출해야 된다.
        cinemachineConfiner.InvalidatePathCache();
    }
}
