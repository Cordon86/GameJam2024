using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selection : MonoBehaviour
{
    
    public GameObject selectedObject;
    public TextMeshProUGUI selectedObjectName;
    private BuildingManager buildingManager;
    
    public GameObject objectUI;


    private void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Selectable"))
                {
                    Debug.Log("Hit object!");
                    Select(hit.collider.gameObject);
                }
            }
        }
        
        if(Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Deselect();
        }
    }

    
    private void Select(GameObject obj)
    {
        if (obj == selectedObject)
        {
            return;
        }
        if (selectedObject != null)
        {
            Deselect();
        }
        
        Outline outline = obj.GetComponent<Outline>();  
        
        if(outline == null)
        {
            outline = obj.AddComponent<Outline>();
        }
        else
        {
            outline.enabled = true;
        }
        
        objectUI.SetActive(true);
        //selectedObjectName.text = obj.name;
        selectedObject = obj;
    }
    
    private void Deselect()
    {
        objectUI.SetActive(false);
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }

    public void Upgrade()
    {
        // TODO do some actual upgrade code
    }

    public void Delete()
    {
        // TODO refund the cost of the object
        
        GameObject thisObject = selectedObject;
        Deselect();
        Destroy(thisObject);
    }
}
