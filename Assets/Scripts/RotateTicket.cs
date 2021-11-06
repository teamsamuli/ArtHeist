using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTicket : MonoBehaviour
{
    public float degreesPerSecond = 40;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }
}
