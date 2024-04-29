using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] ChunkManager chunkManager;

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("we hit somthing");
        chunkManager.maxSpeed = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        chunkManager.maxSpeed = 40;
    }


}
