using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInputManager : MonoBehaviour
{
    // TODO replace with a different controller?
    PlayerController playerController;
    BuildingManager buildingManager;

    // used by external scripts for building
    public bool enableBuildUI;
    public GameObject builderUI;
    
    public float rotateInput;
    
    private void OnEnable()
    {
        if (playerController == null)
        {
            playerController = new PlayerController();
            
            playerController.BuildActions.RotateTower.performed += i => rotateInput = i.ReadValue<float>();
            //playerController.BuildActions.SelectTower.performed += i => buildingManager.SelectTower(obj);
            
            playerController.GameActions.BuildMode.performed += i => enableBuildUI = true;
            playerController.GameActions.BuildMode.canceled += i => enableBuildUI = false;
        }
        
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }
    
    public void OnMovement()
    {
        
    }

    private void Update()
    {
        Debug.Log("enabelBuildUI: " + enableBuildUI);
    }


}
