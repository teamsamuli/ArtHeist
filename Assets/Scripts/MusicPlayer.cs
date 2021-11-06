using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSrc;

    public AudioClip notSpottedMusic;
    public AudioClip spottedMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        audioSrc.clip = notSpottedMusic;
        audioSrc.loop = true;
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
