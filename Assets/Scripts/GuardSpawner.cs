using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner : MonoBehaviour
{

    /// <summary>
    /// Prefab for generating new guards. Fill this in Unity
    /// </summary>
    public Guard GuardTemplate;

    /// <summary>
    /// List of spawned guards
    /// </summary>
    private List<Guard> SpawnedGuards;

    /// <summary>
    /// Number of active guards
    /// </summary>
    public int NumberOfActiveGuards = 3;

    /// <summary>
    /// Number of seconds to wait between spawning.
    /// </summary>
    public float SpawnDelay = 10f;


    private float timeTracker;

    // Start is called before the first frame update
    void Start()
    {
        SpawnedGuards = new List<Guard>();

        SpawnNewGuards(NumberOfActiveGuards);

        timeTracker = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time - timeTracker > SpawnDelay)
        {
            int livingGuards = 0;

            foreach(Guard trackedGuard in SpawnedGuards)
            {
                if (trackedGuard.isAlive)
                {
                    livingGuards++;
                }
            }

            if (livingGuards < NumberOfActiveGuards)
            {
                SpawnNewGuards(NumberOfActiveGuards - livingGuards);
            }
        }
    }

    private void SpawnNewGuards(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            Guard newGuard = Instantiate(GuardTemplate, gameObject.transform.position, Quaternion.identity);
            SpawnedGuards.Add(newGuard);
        }
    }
}
