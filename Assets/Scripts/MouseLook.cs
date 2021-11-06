using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    PickUp pickUp;
    public float mouseSensitivity = 100f;
    public GameObject destination;
    public Transform cameraPos;
    public Transform playerBody;
    public LayerMask Objects;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // lukitsee kursorin jos klikkaapeli‰ (tai on in focus)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //k‰ytt‰‰ unityn sis‰isi‰ hiiren ominaisuuksia
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        
        xRotation -= mouseY;
        // Lukitsee ettei katse mene yli ylimm‰n kohdan tai ali alimman kohdan
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //Pick up item
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, Objects))
            {
                Debug.Log(hit.transform.name);
                pickUp = hit.transform.GetComponent<PickUp>();
                pickUp.PickItemUp();
            }
        }    

        //Drop item
        if (Input.GetMouseButtonDown(1))
        {
            pickUp.DropItem();
        }

        //Throw item
        if (destination.transform.childCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickUp.ThrowItem(transform.forward, 10f);
            }
        }

    }

}