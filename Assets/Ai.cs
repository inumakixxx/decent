using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public Tar path;
    public Car car {get; private set;}
    public float distanceThreshold;
    public int nextWaypoint;

    public void Awake()
    {
        car = GetComponent<Car>();
        FindClosestWaypoint();
    }
    void FindClosestWaypoint()
    {
        float closesDistance = float.MaxValue;
        int closesWaypoint = -1;

        Vector3 myPosition = transform.position;
        for (int i = 0; i < path.waypoints.Length; i++)  {
            float distance = Vector3.Distance(path.waypoints[i].transform.position,myPosition);
            if(distance < closesDistance){
                closesDistance = distance;
                closesWaypoint = i;
            }
        }   
        nextWaypoint = closesWaypoint;   
            
        
    }
    void Update(){
        Vector3 targetWpoint = path.waypoints[nextWaypoint].transform.position;
        Vector3 target = new Vector3(targetWpoint.x , transform.position.y, targetWpoint.z);

        Vector3 vectorToTarget = transform.InverseTransformPoint(target);
        float distanceToTarget = vectorToTarget.magnitude;

        if(distanceToTarget <= distanceThreshold){
            nextWaypoint = (nextWaypoint + 1) % path.waypoints.Length;
        }
        float forward = 1.0f;
        float steer = vectorToTarget.x / distanceToTarget;

        car.forward = forward;
        car.turn = steer;
    }
    
    

}
