using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner : MonoBehaviour
{

    public GameObject GuardTemplate;

    public List<GameObject> SpawnedGuards;

    // Start is called before the first frame update
    void Start()
    {
        SpawnedGuards = new List<GameObject>();

        GameObject newGuard = Instantiate(GuardTemplate, gameObject.transform.position, Quaternion.identity);

        SpawnedGuards.Add(newGuard);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
