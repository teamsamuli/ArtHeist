using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject_AddScore : MonoBehaviour
{
    Collider col;
    MeshRenderer mesh;

    public AudioSource tickSource;
    public int scoreAmount = 10;
    public GameObject effectPrefab;

    bool destroyBlock = false;

    void Start()
    {
        //Get collider & meshrenderer
        col = GetComponent<Collider>();
        if (col == null) col = GetComponentInChildren<Collider>();

        mesh = GetComponent<MeshRenderer>();
        if (mesh == null) mesh = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyBlock)
        {
            destroyBlock = false;

            //Hide mesh & disable collider
            mesh.enabled = false;
            col.enabled = false;

            //Particle effect
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1f);

            Destroy(gameObject, 2);

            Score.score += scoreAmount;
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
