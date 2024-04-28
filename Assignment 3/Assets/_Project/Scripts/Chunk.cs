using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public static float speed;

    void Update()
    {
        calcSpeedLimited();


        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime); //speed m / sec 

        if (transform.position.z < ChunkManager.instance.outOfScreenPostition.z)
        {
            ChunkManager.instance.reallocate(gameObject);
        }

        Debug.Log(speed);
    }


    void calcSpeedLimited()
    {
        if (speed < ChunkManager.instance.maxSpeed)
        {
            speed = speed + (1 * Time.deltaTime);
        }

        else if (speed > ChunkManager.instance.maxSpeed)
        {
            speed = speed - (1 * Time.deltaTime);
        }
    }
}
