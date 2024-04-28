using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private ChunkManager chunkManager;

    private void Start()
    {
        chunkManager = GetComponent<ChunkManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        chunkManager.maxSpeed = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        chunkManager.maxSpeed = 10;
    }
}
