using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwivelSecurityCam : MonoBehaviour
{
    float endedRotation;

    float timeDelayBetweenRotations = 10f;

    bool IsFacingLeft = false;

    bool isRotating = false;

    float RotatedDegrees = 0;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.Rotate(Vector3.up, -45, Space.World); // prepare for rotation by facing left
        IsFacingLeft = true;
        endedRotation = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if not rotating yet and enough time has passed after previous rotation
        if (!isRotating && Time.time - endedRotation > timeDelayBetweenRotations)
        {
            isRotating = true;
            Debug.Log("Started Rotating");
        }

        if (isRotating)
        {
            float rotateBy = 90;

            if (!IsFacingLeft) // if is not facing left, then reverse the rotation direction
            {
                rotateBy = rotateBy * -1;
            }

            float rotateAmount = rotateBy * Time.deltaTime;

            RotatedDegrees = RotatedDegrees + rotateAmount;

            // Slowly pan the camera to other side
            gameObject.transform.Rotate(Vector3.up, rotateAmount, Space.World);

            Debug.Log(RotatedDegrees.ToString());
            if (RotatedDegrees > 90 || RotatedDegrees < -90)
            {
                Debug.Log("Finished Rotating");
                isRotating = false;
                endedRotation = Time.time;
                IsFacingLeft = !IsFacingLeft; // Now set the direction to reverse next time
                RotatedDegrees = 0; // Reset the rotation to prevent overrotating
            }
        }
    }

}
