using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject moveMe;
    Rigidbody rb;
    private float MovementSpeed = 10f;

    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 Movements = new Vector3(Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime);
        moveMe.transform.Translate(Movements);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        { 
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
    
    }
    bool IsGrounded()
    {
        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)) return true;
        return false;
    }
}
