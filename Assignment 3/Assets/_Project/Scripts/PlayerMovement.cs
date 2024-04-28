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
    
    // Start is called before the frst frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // KISS  keep it stupid simple 
        if (Input.GetAxis("Horizontal") > 0.1f && transform.position.x <snapDistance && !isMoving)
        {
            //TODO Make code to snap to the right
            // exact constant moves
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

    private void OnCollisionExit(Collision other)
    {
    
    }
}
