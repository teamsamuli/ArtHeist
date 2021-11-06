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
    /// List for allowed guard spawn points.
    /// </summary>
    public List<Transform> SpawnPoints;

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
        // If no defined spawn points, then just spawn where the GuardHandler game object is located
        Transform spawnPoint = gameObject.transform;

        for (int i = 0; i < howMany; i++)
        {
            if (SpawnPoints.Count >= i+1) // Use spawn points if they have been defined
            {
                spawnPoint = SpawnPoints[i];
            }

            Guard newGuard = Instantiate(GuardTemplate, spawnPoint.position, Quaternion.identity);
            SpawnedGuards.Add(newGuard);
        }
    }

    public bool IsPlayerSpotted()
    {
        bool isSpotted = false;
        foreach(Guard guard in SpawnedGuards)
        {
            if (guard.IsChasing()) isSpotted = true;
        }

        return isSpotted;
    }
}
