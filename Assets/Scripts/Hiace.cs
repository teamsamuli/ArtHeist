using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiace : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip scoreSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Objects"))
        {
            audioSrc.PlayOneShot(scoreSound, 1f);
        }
    }
}
