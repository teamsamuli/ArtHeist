using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public Transform mouselook;
    public float smoothingSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Smooth position
        Vector3 targetPosition = new Vector3(mouselook.position.x, mouselook.position.y, mouselook.position.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, smoothingSpeed * Time.deltaTime);

        //Smooth rotation
        Quaternion targetRotation = Quaternion.Euler(mouselook.localEulerAngles.x, player.localEulerAngles.y, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothingSpeed * Time.deltaTime);
    }
}
