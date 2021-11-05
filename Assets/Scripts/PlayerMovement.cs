using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject moveMe;
    Rigidbody rb;
    public float MovementSpeed = 10f;
    public float SprintSpeed = 20f;
    public float jumpHeight = 3f;
    private Vector3 movement = new Vector3(0f, 0f, 0f);
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;

    float moveX, moveZ;


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




        if (Input.GetButtonDown("Jump") && IsGrounded()) //Jump
        { 
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
    
    }
    private void FixedUpdate()
    {
        //Get move direction
        Vector3 moveDir = transform.right * moveX + transform.forward * moveZ;

        if (Input.GetKey(KeyCode.LeftShift)) //Run 
        {
            rb.MovePosition(transform.position + moveDir * Time.deltaTime * SprintSpeed);
        }
        else //Walk
        {
            rb.MovePosition(transform.position + moveDir * Time.deltaTime * MovementSpeed);
        }
    }
    bool IsGrounded()
    {
        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)) return true;
        return false;
    }
}
