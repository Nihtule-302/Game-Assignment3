using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    [SerializeField] float speed;

    int direction = 1;


    void Update()
    {
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);

    }

    public void playerNotLooking() {

        direction = 1;

    }

    public void goBack() {
        direction = -1;
    }
}
