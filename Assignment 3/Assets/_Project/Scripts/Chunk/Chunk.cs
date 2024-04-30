using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public static float speed;

    ChunkManager chunkManager;

    void Awake()
    {
        chunkManager = GameObject.FindGameObjectWithTag("ChunkManager").GetComponent<ChunkManager>();
        
    }

    void Update()
    {
        calcSpeedLimited();


        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime); 

        if (transform.position.z < chunkManager.outOfScreenPostition.z)
        {
            ChunkManager.instance.reallocate(gameObject);
        }

        Debug.Log(speed);
    }


    void calcSpeedLimited()
    {
        if (speed < chunkManager.maxSpeed)
        {
            speed = speed + (1 * Time.deltaTime);
        }

        else if (speed > chunkManager.maxSpeed)
        {
            speed = speed - (1 * Time.deltaTime);
        }
    }
}
