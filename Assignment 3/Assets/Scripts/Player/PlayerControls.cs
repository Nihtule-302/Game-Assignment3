using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    AudioManager audioManager;
    EnemyControl enemyControl;
    Player player;

    private bool isMoving;
    private String currentCamera = "primary";
    private bool isPushingBack = false;

    [Header("Gameplay Values")]
    [SerializeField] private float snapTime;
    [SerializeField] private float snapDistance;

    private void Awake()
    {
        enemyControl = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyControl>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (currentCamera.Equals("primary"))
        {
            enemyControl.playerNotLooking();
            handlePrimaryViewMovement();
        }

        if (currentCamera.Equals("front"))
        {

            handleFrontViewMovement();
            pushBackEnemy();

        }
    }

    void handlePrimaryViewMovement() 
    {
        if (Input.GetAxis("Horizontal") > 0.1f && transform.position.x < snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x + snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }

        if (Input.GetAxis("Horizontal") < -0.1f && transform.position.x > -snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x - snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }
    }

    void handleFrontViewMovement() 
    {
        if (Input.GetAxis("Horizontal") > 0.1f && transform.position.x > -snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x - snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }

        if (Input.GetAxis("Horizontal") < -0.1f && transform.position.x < snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x + snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }
    }

    void stopMoving()
    {
        isMoving = false;
    }

    void pushBackEnemy() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyControl.goBack();
            isPushingBack = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            enemyControl.playerNotLooking();
            isPushingBack = false;
        }

        if (isPushingBack)
        {
            player.takeDamage(0.05f);
        }
    }


    public void changeToPrimaryCamera() {
        currentCamera = "primary";
    }

    public void changeToFrontCamera()
    {
        currentCamera = "front";
    }

}
