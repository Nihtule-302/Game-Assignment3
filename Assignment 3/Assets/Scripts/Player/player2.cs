using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{

    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
