using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    PlayerController playerController;
    [SerializeField] private Vector2 movementInput;

     private void OnEnable()
    {
        if (playerController == null)
        {
            playerController = new PlayerController();
            
            playerController.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        
        playerController.Enable();
    }
    
    private void OnDisable()
    {
        playerController.Disable();
    }
}
