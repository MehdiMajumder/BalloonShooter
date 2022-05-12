using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Starting the spawn at the beginning and repeating every 2 seconds
        InvokeRepeating("Spawn", 0f, 2f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void Spawn()
    {
        // Positioning where the ballons will be spawned (Same position a the spawner)
        Instantiate(balloonPrefab, transform.position, transform.rotation);
    }
}
