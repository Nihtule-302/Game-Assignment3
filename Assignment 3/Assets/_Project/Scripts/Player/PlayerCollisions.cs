using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    Player player;
    PlayerControls playerControls;
    ChunkManager chunkManager;
    EnemyControl enemyControl;

    void Awake()
    {
        player = GetComponent<Player>();
        playerControls = GetComponent<PlayerControls>();

        chunkManager = GameObject.FindGameObjectWithTag("ChunkManager").GetComponent<ChunkManager>();
        enemyControl = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyControl>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyControl.stop();
            player.takeDamage(player.maxHealth);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SlowDownCoin"))
        {
            chunkManager.maxSpeed = 10;
            player.takeDamage(20);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SlowDownCoin"))
        {
            chunkManager.maxSpeed = 40;
        }
    }

}
