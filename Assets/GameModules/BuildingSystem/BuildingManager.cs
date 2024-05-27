using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] traps;
    
    private GameObject pendingTower;
    private Vector3 placePosition;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if(pendingTower != null)
        {
            pendingTower.transform.position = placePosition;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
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
    
    public void PlaceTower()
    {
        pendingTower = null;
    }
    
    public void SelectTower(int index)
    {
        pendingTower =  Instantiate(towers[index], placePosition, transform.rotation);
    }
}
