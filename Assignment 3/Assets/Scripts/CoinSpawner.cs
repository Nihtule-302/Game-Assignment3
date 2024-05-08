using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;

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
            float[] values = { -2.5f, 0, 2.5f };
            int randomIndex = Random.Range(0, 3);
            float x = values[randomIndex];

            spawnPoint = new Vector3(x, 1f, transform.position.z);

            Instantiate(coin, spawnPoint, Quaternion.identity);
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
