using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // If the collision is with player, alert a guard to player position
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            WaypointManager.SetPriorityWaypoint(other.gameObject.transform.position);
        }
    }
}
