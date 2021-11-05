using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Destination;
    public Rigidbody CubeRb;
    public Camera cam;


    public void PickItemUp()
    {
        //These ones freeze and disable collider once you pick up the object
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        CubeRb.constraints = RigidbodyConstraints.FreezePosition;

        //These put the object in to the "destination" and adds it as a child
        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        //this one stops the momentum so it doesnt float away from your hands
        transform.position = Destination.position;
        CubeRb.velocity = Vector3.zero;
        CubeRb.angularVelocity = Vector3.zero;
        
    }
    public void DropItem()
    {
        //These ones unfreeze when you drop it
        this.transform.parent = null;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        CubeRb.constraints = RigidbodyConstraints.None;


    }
    public void ThrowItem(Vector3 direction, float throwForce)
    {
        DropItem();
        CubeRb.AddForce(direction * throwForce, ForceMode.Impulse);
    }

}
