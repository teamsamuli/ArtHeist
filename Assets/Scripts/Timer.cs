using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    public float targetTime = 99999999.0f; //Start value seconds

    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        // yeet code into here
    }


}