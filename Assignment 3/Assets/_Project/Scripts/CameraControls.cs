using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    PlayerControls playerControls;

    void Awake()
    {
        playerControls = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
