using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    PlayerController playerController;
    public Vector2 movementInput;
    public float horizontalInput;
    public float verticalInput;

    public Vector2 cameraInput;
    
    public float cameraInputX;
    public float cameraInputY;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  MonoBehaviour Functions
     */

     private void OnEnable()
    {
        if (playerController == null)
        {
            playerController = new PlayerController();
            
            playerController.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerController.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
        
        playerController.Enable();
    }
    
    private void OnDisable()
    {
        playerController.Disable();
    }

    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  Public Functions
     */
    public void HandleAllInputs()
    {
        HandleMovementInput();
        // Do jump input
        // Do crouch input
        // Do sprint input
        // Do attack input
        // Do interact input
        // Do pause input
        
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  Private Functions
     */
    
    void HandleMovementInput()
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
        
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }
}
