using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    
    [SerializeField] ChunkManager chunkManager;
    [SerializeField] EnemyControl enemyControl;

    void Awake()
    {
        chunkManager = GameObject.FindGameObjectWithTag("ChunkManager").GetComponent<ChunkManager>();
        enemyControl = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyControl>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("stop");
            enemyControl.stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SlowDownCoin"))
        {
            Debug.Log("slowDown");
            chunkManager.maxSpeed = 10;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SlowDownCoin"))
        {
            Debug.Log("Fast");
            chunkManager.maxSpeed = 40;
        }
    }
}
