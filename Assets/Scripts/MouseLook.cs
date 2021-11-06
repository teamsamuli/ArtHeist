using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    PickUp pickUp;
    Rigidbody rb;

    public float mouseSensitivity = 2f;
    public GameObject destination;
    public Transform playerBody;
    public LayerMask Objects;
   
    float mouseX, mouseY;
    float xRotation = 0f;

    float chargeTimer = 0f;
    float chargeTimeMax = 1f;
    public float throwForce = 25f;

    // Start is called before the first frame update
    void Start()
    {
        //Get player rigidbody
        rb = GetComponentInParent<Rigidbody>();

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse movement
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //Apply vertical rotation and clamp it
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotate player horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        //Pick up item
        if (Input.GetMouseButtonDown(0))
        {
            if (IsLookingObject())
            {
                pickUp.PickItemUp(destination.transform);
            }
        }
        else
        {
            if (destination.transform.childCount > 0)
            {
                //Drop item
                if (Input.GetMouseButtonDown(1))
                {
                    pickUp.DropItem();
                }

                //Charge timer starts
                if (Input.GetMouseButton(0))
                {
                    chargeTimer += Time.deltaTime;
                    if (chargeTimer >= chargeTimeMax)
                    {
                        chargeTimer = chargeTimeMax;
                    }
                }

                //Throws with the force of the timer
                if (Input.GetMouseButtonUp(0))
                {
                    if (chargeTimer > 0.2f) Throw();
                    else chargeTimer = 0;
                }
            }
        }
    }

    void Throw()
    {
        pickUp.ThrowItem(transform.forward, throwForce * GetThrowMult());
        chargeTimer = 0;
    }

    public bool IsLookingObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, Objects))
        {
            pickUp = hit.transform.GetComponent<PickUp>();
            return true;
        }

        return false;
    }

    public float GetThrowMult()
    {
        return chargeTimer / chargeTimeMax;
    }
}