using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    
    //Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody rigidBodyPlayer;
    
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 15.0f;
    
    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  MonoBehaviour Functions
     */

    void Awake()
    {
        Debug.Log("PlayerMovement Awake");
        
        Transform testobject = GameObject.Find("Main Camera").transform;
        if (testobject == null)
        {
            Debug.Log("(testobject) Camera not found");
        }
        
        
        rigidBodyPlayer = GetComponent<Rigidbody>();
        if (rigidBodyPlayer == null)
        {
            Debug.Log("(rigidBodyPlayer) Rigidbody not found");
        }
        
        
        inputManager = GetComponent<InputManager>();
        if(inputManager == null)
        {
            Debug.Log("(inputManager) Input Manager not found");
        }
        
        
        cameraObject = Camera.main.transform;
        if(cameraObject == null)
        {
            Debug.Log("(cameraObject) Camera not found");
        }
    } 
   
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
    *  Public Functions
    */
    
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
    

    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
     *  Private Functions
     */
    
    private void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= movementSpeed;
        
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
}


