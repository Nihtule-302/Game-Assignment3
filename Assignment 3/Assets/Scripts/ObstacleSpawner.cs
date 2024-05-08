using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;

    public float spawnInterval = 10f; // Interval between spawns in seconds
    public Vector3 spawnPoint;

    void Start()
    {
        // Start spawning objects
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            float[] values = { -2.5f, 0, 2.5f };
            int randomIndex = Random.Range(0, 3);
            float x = values[randomIndex];

            spawnPoint = new Vector3(x, 0, transform.position.z);

            Instantiate(obstacle, spawnPoint, Quaternion.identity);
        }
    }

}
