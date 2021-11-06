using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwivelSecurityCam : MonoBehaviour
{
    /// <summary>
    /// Used to measure time until next rotation
    /// </summary>
    float endedRotation;

    /// <summary>
    /// Time delay between rotations in seconds
    /// </summary>
    public float timeDelayBetweenRotations = 10f;

    /// <summary>
    /// Number of degrees the camera will rotate
    /// </summary>
    public float RotateByDegrees = 90f;

    /// <summary>
    /// Boolean used to know, which way to rotate the camera next
    /// </summary>
    bool IsFacingLeft = false;

    /// <summary>
    /// Do not check the time when rotating the camera
    /// </summary>
    bool isRotating = false;

    /// <summary>
    /// Variable to track how many degrees the camera has rotated to prevent overrotation
    /// </summary>
    float RotatedDegrees = 0;

    // Start is called before the first frame update
    void Start()
    {
        IsFacingLeft = true;
        endedRotation = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if not rotating yet and enough time has passed after previous rotation
        if (!isRotating && Time.time - endedRotation > timeDelayBetweenRotations)
        {
            isRotating = true; // Time has passed, start rotating
            //Debug.Log("Started Rotating");
        }

        if (isRotating) // Camera is rotating
        {
            RotateCamera();
        }
    }

    private void RotateCamera()
    {
        float rotateBy = RotateByDegrees;

        if (!IsFacingLeft) // if is not facing left, then reverse the rotation direction
        {
            rotateBy = rotateBy * -1;
        }

        float rotateAmount = rotateBy * Time.deltaTime; // Smooth rotation

        RotatedDegrees = RotatedDegrees + rotateAmount; // Track the amount of rotated degrees to know when to stop

        // Slowly pan the camera to other side
        gameObject.transform.Rotate(Vector3.up, rotateAmount, Space.World);

        //Debug.Log(RotatedDegrees.ToString());
        if (RotatedDegrees > 90 || RotatedDegrees < -90)
        {
            //Debug.Log("Finished Rotating");
            isRotating = false; // Not rotating anymore
            endedRotation = Time.time; // Timestamp to know the end time
            IsFacingLeft = !IsFacingLeft; // Reverse the rotation direction for next time
            RotatedDegrees = 0; // Reset the rotation tracking to prevent overrotating
        }
    }

}
