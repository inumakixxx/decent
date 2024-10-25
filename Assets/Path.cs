using UnityEngine;

public class Path : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic WayPoint[] waypoints;
    public Waypoint[] waypoints;
    private void OnDrawGizmos(){
        if(waypoints == null || waypoints.Length < 2){
            return;
        }

        Gizmos.color = Color.white;
        for(int i = 0; i < waypoints.Length ; i++){
            Gizmos.DrawLine(waypoints[i].transform.position, waypoints[(i+1)% waypoints.Length].transform.position);
        }

    }
}
