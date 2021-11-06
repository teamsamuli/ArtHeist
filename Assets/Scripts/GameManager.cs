using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    AudioSource audioSrc;

    public float maxTime = 5f;
    public bool gameStarted;
    public bool gameEnded;

    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        if (game == null) game = this;

        audioSrc = GetComponent<AudioSource>();

        timeLeft = maxTime * 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            //Timer
            if (!gameEnded)
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    if (timeLeft < 0) timeLeft = 0;
                }
                else
                {
                    gameEnded = true;

                    audioSrc.Stop();
                }
            }
        }
    }

    public void StartGame()
    {
        gameStarted = true;

        audioSrc.Play();
        audioSrc.loop = true;
    }

    public float GetTimeMultLeft()
    {
        return timeLeft / (maxTime * 60);
    }
}
