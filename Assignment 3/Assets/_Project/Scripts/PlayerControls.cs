using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{   
    [Header("Gameplay Values")]
    [SerializeField] private float snapTime;
    [SerializeField] private float snapDistance;

    [SerializeField] AudioManager audioManager;

    private bool isMoving;
    private bool isGrounded;
    
    void Update()
    {
   
        if (Input.GetAxis("Horizontal") > 0.1f && transform.position.x < snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x +snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }
        
        if(Input.GetAxis("Horizontal")<-0.1f && transform.position.x > -snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x -snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }

    }

    void stopMoving()
    {
        isMoving = false;
    }
    

}
