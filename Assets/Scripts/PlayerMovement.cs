using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    MouseLook mouseLook;
    AudioSource audioSrc;
    UIManager UI;

    [Header("Audio")]
    public Subtitle[] subtitles;

    [Header("Stats")]
    public float walkSpeed = 4f;
    public float sprintSpeed = 8f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;

    float moveX, moveZ;
    float moveSpeed;
    bool canEscape;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
        UI = transform.parent.GetComponentInChildren<UIManager>();
        mouseLook = GetComponentInChildren<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!UI.tutorialEnded)
            return;

        //Escape input
        if (canEscape)
            if (Input.GetKeyDown(KeyCode.E))
                GameManager.game.EndGame();

        //Get input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
       
        if (IsGrounded())
        {
            //Apply walk speed
            moveSpeed = walkSpeed;

            //Override to run speed
            if (Input.GetKey(KeyCode.LeftShift) && moveZ > 0 && mouseLook.CanRun())
                moveSpeed = sprintSpeed;

            //Jump
            if (Input.GetButtonDown("Jump"))
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        //Get move direction
        Vector3 moveDir = transform.right * moveX + transform.forward * moveZ;
        moveDir = Vector3.ClampMagnitude(moveDir, 1f);

        //Add force
        rb.AddForce(moveDir, ForceMode.Impulse);

        //Clamp movement
        float verticalVelocity = Mathf.Clamp(rb.velocity.y, float.MinValue, jumpHeight);
        Vector3 horizontalVelocity = new Vector3(moveDir.x * moveSpeed, verticalVelocity, moveDir.z * moveSpeed);
        rb.velocity = horizontalVelocity;
    }

    bool IsGrounded()
    {
        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)) return true;
        return false;
    }

    public void PlayRandomEstonian()
    {
        Subtitle randomSubtitle = subtitles[Random.Range(0, subtitles.Length)];
        UI.UpdateSubtitles(randomSubtitle.text);

        audioSrc.PlayOneShot(randomSubtitle.audio, 1f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "LeaveArea")
        {
            canEscape = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "LeaveArea")
        {
            canEscape = false;
        }
    }
}
