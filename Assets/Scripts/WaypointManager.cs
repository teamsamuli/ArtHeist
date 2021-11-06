using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager waypoint;

    public Transform[] waypoints;

    /// <summary>
    /// Priority waypoint. Used to send next free guard to location.
    /// </summary>
    private static Vector3 priorityWaypoint = Vector3.zero;

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
        if (priorityWaypoint != Vector3.zero) // If priority waypoint has been set, return it instead of random waypoint
        {
            Vector3 returnWaypoint = priorityWaypoint;
            priorityWaypoint = Vector3.zero;
            return returnWaypoint;
        }

        return waypoints[Random.Range(0, waypoints.Length)].position;
    }

    /// <summary>
    /// Allow for setting of priority waypoint for next free guard.
    /// </summary>
    /// <param name="newPriority"></param>
    public static void SetPriorityWaypoint(Vector3 newPriority)
    {
        if (priorityWaypoint == Vector3.zero)
        {
            priorityWaypoint = newPriority;
        }
    }
}
