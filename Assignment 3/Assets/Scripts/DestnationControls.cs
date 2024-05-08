using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestnationControls : MonoBehaviour
{
    [SerializeField] float speed;

    [Range(0, 1)]
    [SerializeField] float speedFactor;

    void Update()
    {
        speed = Chunk.speed * speedFactor;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
