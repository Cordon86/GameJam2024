using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerMovement;
    CameraManager cameraManager;
    
    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  MonoBehaviour Functions
     */
    
    private void Awake()
    {
        playerMovement = GetComponent<PlayerLocomotion>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        //cameraManager = GetComponent<CameraManager>();
        ;
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    
    private void FixedUpdate()
    {
        playerMovement.HandleAllMovements();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
