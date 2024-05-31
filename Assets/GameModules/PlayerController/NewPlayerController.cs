using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class NewPlayerController : MonoBehaviour
{
    // Reference to the InputReader scriptable object
    [Header("Input Reader SO")]
    [SerializeField] private InputReader input;
    
    [Header("Movement options")]
    [SerializeField] private float walkSpeed = 10.0f;
    [SerializeField] private float sprintSpeed = 15.0f;
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 15.0f;

    //***** Private variables
    Transform cameraObject;
    Rigidbody rigidBodyPlayer;
    Vector2 moveDirection;
    bool isJumping;
    bool isSprinting;

    //***** Monobehaviour functions
    #region Monobehaviour functions
    private void Awake()
    {
        rigidBodyPlayer = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    void Start()
    {
        // Subscribe to the events
        input.MoveEvent += HandleMove;
        
        input.JumpEvent += HandleJump;
        input.JumpCanceledEvent += HandleJumpCanceled;
        
        input.SprintEvent += HandleSprint;
        input.SprintCanceledEvent += HandleSprintCanceled;
    }

    
    void Update()
    {
        //Sprint();
        Move();
        Rotation();
        Jump();
        // do crouch
        // do attack
        // do interact
    }
    
    #endregion
    

    //***** Movement functions
    #region Movement functions
    
    void Move()
    {
        Vector3 movement = Vector3.zero;
        movement = cameraObject.forward * moveDirection.y;
        movement += cameraObject.right * moveDirection.x;
        movement.Normalize();
        movement.y = 0;
        
        // TODO find a way to do this in its own function?
        if(isSprinting)
        {
            movement *= sprintSpeed;
        }
        else
        {
            movement *= walkSpeed;
        }
        
        Vector3 movementVelocity = movement;
        rigidBodyPlayer.velocity = movementVelocity;
    }
    
    
    private void Rotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * moveDirection.y;
        targetDirection += cameraObject.right * moveDirection.x;
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
    
    void Jump()
    {
        if(isJumping)
        {
            transform.position += Vector3.up * (jumpSpeed * Time.deltaTime);
            isJumping = false;
        }
    }
    
    #endregion
    
    
    //***** Private functions to handle the input
    #region Input Handling functions
    void HandleMove(Vector2 dir)
    {
        moveDirection = dir;
    }
    
    
    void HandleJump()
    {
        isJumping = true;
    }
    
    
    void HandleJumpCanceled()
    {
        isJumping = false;
    }
    
    
    void HandleSprint()
    {
        isSprinting = true;
    }
    
    
    void HandleSprintCanceled()
    {
        isSprinting = false;
    }

    #endregion
    
    
}
