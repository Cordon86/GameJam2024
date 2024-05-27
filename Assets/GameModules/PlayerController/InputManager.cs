using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // [SerializeField] private 
    PlayerController playerController;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;
    
    //[Header("Targets & Transforms")]
    private Vector2 movementInput;
    private Vector2 cameraInput;
    
    // Used by external scripts for player locomotion
    public float horizontalInput;
    public float verticalInput;
    public float moveAmount;
    public bool b_Input;
    
    // Used by external scripts for camera movement
    public float cameraInputX;
    public float cameraInputY;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  MonoBehaviour Functions
     */

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerController == null)
        {
            playerController = new PlayerController();
            
            // Friendly reminder for the addled brain:
            // InputActions.ActionMap.Action.performed = do stuff
            // InputActions.ActionMap.Action.canceled = do stuff
            // Also that unity is annoyingly inconcistent with the naming
            // of these things Behaviour(english), canceled(american)
            playerController.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerController.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            
            playerController.PlayerActions.B.performed += i => b_Input = true;
            playerController.PlayerActions.B.canceled += i => b_Input = false;
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
        HandleSprintingInput();      // Do sprint input
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
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
        
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }
    
    void HandleSprintingInput()
    {
        // make sure player is running **no launching into sprinting from stationary and walking**
        if (b_Input && moveAmount > 0.5f)  
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }
}
