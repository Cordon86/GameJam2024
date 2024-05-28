using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

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
    public bool sprintInput;
    
    // Used by external scripts for camera movement
    public float cameraInputX;
    public float cameraInputY;

    //***** MonoBehaviour Functions
    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        // Friendly reminder for the addled brain:
        // InputActions.ActionMap.Action.performed = do stuff
        // InputActions.ActionMap.Action.canceled = do stuff
        
        if (playerController == null)
        {
            playerController = new PlayerController();
            
            playerController.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerController.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            
            playerController.PlayerActions.Sprint.performed += i => sprintInput = true;
            playerController.PlayerActions.Sprint.canceled += i => sprintInput = false;

            playerController.PlayerActions.Sprint.performed += DoSprint;

        }
        
        playerController.Enable();
    }

    
    private void OnDisable()
    {
        playerController.Disable();
    }

    
    //***** Public Functions
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
    
    //***** Private Functions
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
        if (sprintInput && moveAmount > 0.5f)  
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }
    
    void DoSprint(InputAction.CallbackContext context)
    {
        Debug.Log("Sprint!");
    } 
}
