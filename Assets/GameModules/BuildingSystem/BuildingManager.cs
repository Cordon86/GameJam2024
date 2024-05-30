using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    /*
     * This class is used to manage the building of towers and traps
     * It is used to place the towers and traps on the grid
     * Towers and traps can be rotated to face different directions
     * TODO: Add the ability to upgrade towers
     * TODO: Add the feature that traps can only be roted by 90 degrees at a time.
     */
    
    // TODO: replace with a different controller?
    /*
    BuildingInputManager buildingInputManager;
    
    BuildingManager buildingManager;
    // [SerializeField] private
    [Header("Towers & Traps")]
    [SerializeField] private GameObject[] towers;
    [SerializeField] private GameObject[] traps;
    
    [Header("Layers & Masks")]
    [SerializeField] private LayerMask layerMask;

    [Header("Grid Settings")]
    [SerializeField] private Toggle gridToggle;
    [SerializeField] private float gridSize = 1.0f;
    bool gridEnabled = true;
    
    public GameObject BuilderUI;
    
    [Header("DO NOT EDIT :- F around and Find Out")]
    public GameObject pendingTower;
    
    
    // Private variables
    private Vector3 placePosition;
    private RaycastHit hit;
    private float rotateValue = 15.0f;
    
    
    
    //***** MonoBehaviour Functions
    private void Update()
    {
        if(pendingTower)
        {
            if (buildingInputManager.enableBuildUI == true)
            {
                BuilderUI.SetActive(true);
            }
            else
            {
                BuilderUI.SetActive(false);
            } 
            
            if(gridEnabled)
            {
                pendingTower.transform.position = new Vector3(
                                                NearestGrid(placePosition.x, gridSize), 
                                                NearestGrid(placePosition.y, gridSize), // maybe set this 0?
                                                NearestGrid(placePosition.z, gridSize)
                                                );
            }
            else
            {
                pendingTower.transform.position = placePosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
            
            //if (Input.GetMouseButtonDown(1))
            //{
            //    RotateTower();
            //}
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            placePosition = hit.point; 
        }
    }
    
    
    //***** public Functions
    public void SelectTower(int index)
    {
        pendingTower =  Instantiate(towers[index], placePosition, transform.rotation);
    }
    
    public void RotateTower()
    {
        if(pendingTower)
        {
            pendingTower.transform.Rotate(0, rotateValue, 0);
        }
    }
    
    public void PlaceTower()
    {
        pendingTower = null;
    }
    
    // used in the UI; Unity shows functions only used by the editor/UI as unused
    public void ToggleGrid()
    {
        if(gridToggle.isOn)
        {
            gridEnabled = true;
        }
        else
        {
            gridEnabled = false;
        }
    }
    
    
    //***** private Functions
    float NearestGrid(float location, float grid)
    {
        float xDiff = location % grid;
        location -= xDiff;
        
        if(xDiff > grid / 2)
        {
            location += grid;
        }

        return location;
    }
    */
}
