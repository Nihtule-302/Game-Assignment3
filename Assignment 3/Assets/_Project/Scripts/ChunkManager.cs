using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int numberOfChunks;
    [SerializeField] private float chunkZPositionFlag =0;
    float chunkLength = 20f;

    public static ChunkManager instance;

    Vector3 targetPostition;
   public Vector3 outOfScreenPostition;
    void Start()
    {
     

        instance = this;
        outOfScreenPostition = new Vector3(0, 0, -chunkLength+5f);
        targetPostition = new Vector3(0, 0, (numberOfChunks - 1) * chunkLength);

        spawnChunks();

        
    }

    void spawnChunks() 
    {
        for (int i = 0; i < numberOfChunks; i++)
        {

            Instantiate(chunkPrefab, new Vector3(transform.position.x, transform.position.y, chunkZPositionFlag), quaternion.identity);
            chunkZPositionFlag += chunkLength;
        }
    }

    public void reallocate(GameObject chunk)
    {
        if (chunk.transform.position.z <= outOfScreenPostition.z) 
        {
            chunk.transform.position = targetPostition;        
        }
    }
}