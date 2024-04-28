using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cached  refrences")]
    [SerializeField] private Rigidbody rb;
    
    
    [Header("Gameplay Values")]
    [SerializeField] private float snapTime;
    [SerializeField] private float snapDistance;
    [SerializeField] private float jumpForce;

    [Header("Checks")]
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isGrounded;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
   
        if (Input.GetAxis("Horizontal") > 0.1f && transform.position.x <snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x +snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }
        
        if(Input.GetAxis("Horizontal")<-0.1f && transform.position.x > -snapDistance && !isMoving)
        {
            isMoving = true;
            LeanTween.moveX(gameObject, transform.position.x -snapDistance, snapTime).setEaseInCubic().setOnComplete(stopMoving);
        }

        if (Input.GetAxis("Jump")>0 && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
    }

    void stopMoving()
    {
        isMoving = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    
}
