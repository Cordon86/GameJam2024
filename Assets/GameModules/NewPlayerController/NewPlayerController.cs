using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewPlayerController : MonoBehaviour
{
    // Reference to the InputReader scriptable object
    [SerializeField] private InputReader input;
    
    [SerializeField] private float walkSpeed = 10.0f;
    [SerializeField] private float sprintSpeed = 15.0f;
    [SerializeField] private float jumpSpeed = 10.0f;

    private float currentSpeed;
    
    Vector2 moveDirection;
    bool isJumping;
    bool isSprinting;
    

    void Start()
    {
        currentSpeed = walkSpeed;
        // Subscribe to the events
        input.MoveEvent += HandleMove;
        
        input.JumpEvent += HandleJump;
        input.JumpCanceledEvent += HandleJumpCanceled;
        
        input.SprintEvent += HandleSprint;
        input.SprintCanceledEvent += HandleSprintCanceled;
    }

    
    void Update()
    {
        Sprint();
        Move();
        Jump();
    }
    
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

    
    void Move()
    {
        if(moveDirection == Vector2.zero)
        {
            return;
        }
        //transform.position += new Vector3(moveDirection.y, 0, moveDirection.x) * (speed * Time.deltaTime);
        transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * (currentSpeed * Time.deltaTime);
    }
    
    
    void Jump()
    {
        if(isJumping)
        {
            transform.position += Vector3.up * (jumpSpeed * Time.deltaTime);
            //isJumping = false;
        }
    }

    void Sprint()
    {
        if (!isSprinting)
        {
            currentSpeed = walkSpeed;
        }

        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
    }
}
