using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    Player player;
    PlayerControls playerControls;
    ChunkManager chunkManager;
    EnemyControl enemyControl;
    AudioManager audioManager;

    void Awake()
    {
        player = GetComponent<Player>();
        playerControls = GetComponent<PlayerControls>();

        chunkManager = GameObject.FindGameObjectWithTag("ChunkManager").GetComponent<ChunkManager>();
        enemyControl = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyControl>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("that hurt");
            chunkManager.maxSpeed = 10;
            player.takeDamage(20);

            Vector3 newPosition = other.gameObject.transform.position;
            newPosition.z = -30f;
            other.gameObject.transform.position = newPosition;

            audioManager.PlaySFX(audioManager.beingHit);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            audioManager.PlaySFX(audioManager.coin);
            enemyControl.playerIsDashing = true;
            chunkManager.maxSpeed = 40;

            Vector3 newPosition = other.gameObject.transform.position;
            newPosition.z = -30f;
            other.gameObject.transform.position = newPosition;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("that hurt");
            enemyControl.stop();
            player.takeDamage(player.maxHealth);
        }

        if (other.gameObject.CompareTag("Win"))
        {
            SceneChanger.changeToWinScene();
        }

    }

}
