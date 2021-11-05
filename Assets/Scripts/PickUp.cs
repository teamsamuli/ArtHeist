using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Destination;
    public Rigidbody CubeRb;

    void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;

        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;

        transform.position = Destination.position;
        CubeRb.velocity = Vector3.zero;
        CubeRb.angularVelocity = Vector3.zero;
        
    }
    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        
    }
}
