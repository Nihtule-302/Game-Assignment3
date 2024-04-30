using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;

    public CinemachineVirtualCamera   primaryCamera;
    public CinemachineVirtualCamera   frontCamera;
    public CinemachineVirtualCamera[] virtualCameras;
    


    [ContextMenu("Get All Virtual Cameras")]
    private void GetAllVirtualCameras() 
    {
        virtualCameras = GameObject.FindObjectsOfType<CinemachineVirtualCamera>();
        primaryCamera = GameObject.FindGameObjectWithTag("Primary Camera").GetComponent<CinemachineVirtualCamera>();
        frontCamera = GameObject.FindGameObjectWithTag("Front Camera").GetComponent<CinemachineVirtualCamera>();
    }


    void Awake()
    {
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    private void Start()
    {
        SwitchToCamera(primaryCamera);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SwitchToCamera(frontCamera);
            playerControls.changeToFrontCamera();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SwitchToCamera(primaryCamera);
            playerControls.changeToPrimaryCamera();
        }
    }

    void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in virtualCameras) 
        {
            camera.enabled = camera == targetCamera;
        }
    }
}
