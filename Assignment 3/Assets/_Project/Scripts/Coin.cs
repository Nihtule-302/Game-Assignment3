using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 50f; 
    void Start()
    {
       
        LeanTween.moveY(gameObject, 1.65F, 1.5f).setLoopPingPong();
    }
   
    void Update()
    {
        
        LeanTween.rotateY(gameObject, transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, Time.deltaTime);
      
    }
}
