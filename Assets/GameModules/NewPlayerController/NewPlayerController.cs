using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField] private InputReader input;
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    
    Vector2 moveDirection;
    bool isJumping;
    

    void Start()
    {
        // Subscribe to the events
        input.MoveEvent += HandleMove;
        
        input.JumpEvent += HandleJump;
        input.JumpCanceledEvent += HandleJumpCanceled;
    }

    
    void Update()
    {
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

    
    void Move()
    {
        if(moveDirection == Vector2.zero)
        {
            return;
        }
        //transform.position += new Vector3(moveDirection.y, 0, moveDirection.x) * (speed * Time.deltaTime);
        transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * (speed * Time.deltaTime);
    }
    
    
    void Jump()
    {
        if(isJumping)
        {
            transform.position += Vector3.up * (jumpSpeed * Time.deltaTime);
            //isJumping = false;
        }
    }
}
