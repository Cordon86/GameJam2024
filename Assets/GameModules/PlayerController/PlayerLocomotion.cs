using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLocomotion : MonoBehaviour
{
    // [SerializeField] private
    InputManager inputManager;
    
    //Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody rigidBodyPlayer;
    
    [Header("Movement options")]
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float moveSpeed = 4.0f;
    [SerializeField] private float runSpeed = 8.0f;
    [SerializeField] private float rotationSpeed = 15.0f;

    // used by external scripts
    public bool isSprinting;
    
    
    //***** MonoBehaviour Functions
    void Awake()
    {
        rigidBodyPlayer = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        cameraObject = Camera.main.transform;
    } 
   
    
    //***** Public Functions
    public void HandleAllMovements()
    {
        HandleMovement();
        HandleRotation();
        // do jump
        // do crouch
        // do sprint
        // do attack
        // do interact
    }
    
    
    //***** Private Functions
    private void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        
        if(isSprinting)
        {
            moveDirection *= runSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)
            {
                moveDirection *= moveSpeed;
            }
            else
            {
                moveDirection *= walkSpeed;
            }
        }
        
        Vector3 movementVelocity = moveDirection;
        rigidBodyPlayer.velocity = movementVelocity;
    }
    
    private void HandleRotation()
    {
        // TODO make the player rotate based on the camera's direction
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection += cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;
        
        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }
  
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        transform.rotation = playerRotation;
    }
    
    public void SetSprinting(bool sprinting)
    {
        isSprinting = sprinting;
    }
}


