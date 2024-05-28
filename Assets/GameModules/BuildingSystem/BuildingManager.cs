using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    // [SerializeField] private
    [Header("Towers & Traps")]
    [SerializeField] private GameObject[] towers;
    [SerializeField] private GameObject[] traps;
    
    [Header("Layers & Masks")]
    [SerializeField] private LayerMask layerMask;

    // Private variables
    private GameObject pendingTower;
    private Vector3 placePosition;
    private RaycastHit hit;
    private float rotateValue = 15.0f;
    
    [SerializeField] private Toggle gridToggle;
    public float gridSize = 1.0f;
    bool gridEnabled = true;
    
    //***** MonoBehaviour Functions
    private void Update()
    {
        if(pendingTower)
        {
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
}
