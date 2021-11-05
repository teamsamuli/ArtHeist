using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject_AddScore : MonoBehaviour
{
    private bool destroyBlock = false;
    public AudioSource tickSource;



    // Update is called once per frame

    void Update()

    {

        if (destroyBlock)

        {

            destroyBlock = false;

            GetComponent<MeshRenderer>().enabled = false;

            GetComponent<Collider>().enabled = false;

            Destroy(gameObject, 2);

            Score.score++;
            tickSource.Play();

        }

    }

    // if collides with "Truck" collider = activate above
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Truck") // Pickupis pakko olla gameobject boxcollider mis tagi "Truck"
        {
            destroyBlock = true;
        }
    }
}
