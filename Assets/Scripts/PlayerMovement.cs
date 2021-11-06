using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float walkSpeed = 10f;
    public float sprintSpeed = 20f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;

    float moveX, moveZ;
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        //Get input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //Apply walk speed
        moveSpeed = walkSpeed;

        //Override to run speed
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = sprintSpeed;

        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded()) //Jump
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);  
    }

    void FixedUpdate()
    {
        //Get move direction
        Vector3 moveDir = transform.right * moveX + transform.forward * moveZ;

        //Add force
        rb.AddForce(moveDir, ForceMode.Impulse);

        //Clamp movement
        Vector3 horizontalVelocity = new Vector3(moveDir.x * moveSpeed, rb.velocity.y, moveDir.z * moveSpeed);
        rb.velocity = horizontalVelocity;
    }

    bool IsGrounded()
    {
        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)) return true;
        return false;
    }
}
