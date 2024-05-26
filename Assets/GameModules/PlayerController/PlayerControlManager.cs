using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerMovement;
    
    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  MonoBehaviour Functions
     */
    
    private void Awake()
    {
        playerMovement = GetComponent<PlayerLocomotion>();
        inputManager = GetComponent<InputManager>();
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    
    private void FixedUpdate()
    {
        playerMovement.HandleAllMovements();
    }
}
