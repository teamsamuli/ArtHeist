using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSrc;
    GuardSpawner guardSpawner;

    public AudioClip spyMusic;
    public AudioClip chaseMusic;

    float updateInterval = 0.5f;
    float lastTimeUpdated;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        guardSpawner = FindObjectOfType<GuardSpawner>();

        audioSrc.clip = spyMusic;
        audioSrc.loop = true;
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if need to change music
        if (Time.time >= lastTimeUpdated + updateInterval)
        {
            lastTimeUpdated = Time.time;

            ChangeSong(guardSpawner.IsPlayerSpotted());
        }
    }

    void ChangeSong(bool playChaseMusic)
    {
        //Dont change if already right song is playing
        if (playChaseMusic && audioSrc.clip == chaseMusic || !playChaseMusic && audioSrc.clip == spyMusic)
            return;

        //Change song
        audioSrc.Stop();
        if (playChaseMusic) audioSrc.clip = chaseMusic;
        else audioSrc.clip = spyMusic;
        audioSrc.Play();
    }
}
