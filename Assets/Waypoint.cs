using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void  OnDrawGizmos()
    {   
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 1.0f);
    }
}
