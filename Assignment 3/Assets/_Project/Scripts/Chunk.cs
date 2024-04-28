using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public static float speed;

    void Update()
    {
        //calcSpeedNoLimit();
        calcSpeedLimited();


        transform.Translate(Vector3.forward*-1*speed * Time.deltaTime); //speed m / sec 

        if (transform.position.z < ChunkManager.instance.outOfScreenPostition.z)
        {
            ChunkManager.instance.reallocate(gameObject);
        }

        Debug.Log(speed);
    }

    void calcSpeedNoLimit() 
    {
        speed = speed + (1  * Time.deltaTime);
    }

    void calcSpeedLimited()
    {
        if (speed < 100)
        {
            speed = speed + (1 * Time.deltaTime);
        }
    }
}
