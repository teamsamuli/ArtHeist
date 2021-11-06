using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager waypoint;

    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        if (waypoint == null)
            waypoint = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetRandomWaypoint()
    {
        return waypoints[Random.Range(0, waypoints.Length)].position;
    }
}
