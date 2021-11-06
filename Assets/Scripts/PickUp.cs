using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Rigidbody rb;
    Collider col;

    void Start()
    {
        //Get rigidbody and collider
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        if (col == null) col = GetComponentInChildren<Collider>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        //Update positon if object is in hand
        if (transform.parent != null)
            if (transform.parent.gameObject.layer == LayerMask.NameToLayer("Player"))
                transform.localPosition = Vector3.zero;
    }

    public void PickItemUp(Transform destination)
    {
        //These ones freeze and disable collider once you pick up the object
        col.enabled = false;
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezePosition;

        //Put object in correct position in "hands"
        transform.parent = destination;
        transform.localPosition = Vector3.zero;

        //this one stops the momentum so it doesnt float away from your hands
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;        
    }

    public void DropItem()
    {
        //Disable parent
        transform.parent = null;
        
        //Enable collider
        col.enabled = true;

        //Activate rigidbody
        rb.useGravity = true;
        rb.freezeRotation = false;       
        rb.constraints = RigidbodyConstraints.None;
    }

    public void ThrowItem(Vector3 direction, float throwForce)
    {
        DropItem();

        rb.AddForce(direction * throwForce, ForceMode.Impulse);
    }

}
