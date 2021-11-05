using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject moveMe;
    private float MovementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        Vector3 Movements = new Vector3(Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime);
        moveMe.transform.Translate(Movements);
    }
}
