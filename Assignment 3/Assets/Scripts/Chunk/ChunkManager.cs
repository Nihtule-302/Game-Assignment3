using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int numberOfChunks;
    [SerializeField] private float chunkZPositionFlag =0;
    [SerializeField] float chunkLength = 15f;

    public static ChunkManager instance;

    public float maxSpeed = 10f;
    public bool dash = false;

    Vector3 targetPostition;
    public Vector3 outOfScreenPostition;

    void Start()
    {
        instance = this;
        outOfScreenPostition = new Vector3(0, 0, -2* chunkLength+5f);
        targetPostition = new Vector3(0, 0, (numberOfChunks - 2) * chunkLength);

        spawnChunks();
    }

    void spawnChunks() 
    {
        Instantiate(chunkPrefab, new Vector3(transform.position.x, transform.position.y, -chunkLength), Quaternion.identity);
        for (int i = 0; i < numberOfChunks-1; i++)
        {

            Instantiate(chunkPrefab, new Vector3(transform.position.x, transform.position.y, chunkZPositionFlag), Quaternion.identity);
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
