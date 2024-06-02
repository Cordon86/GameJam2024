using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuControls : MonoBehaviour
{
    [Header("Input Reader SO")]
    [SerializeField] private InputReader input;

    [Header("UI Elements")]
    [SerializeField] private List<GameObject> uiButtons;
    [SerializeField] private GameObject firstButtonbutton;
    
    
    
    void OnEnable()
    {
        input.MoveSelectionEvent += HandleMoveSelection;
        
        // move the selection
        var currentIndex = uiButtons.IndexOf(EventSystem.current.currentSelectedGameObject);
        EventSystem.current.SetSelectedGameObject(null);                    //clear the currently selected game object
        EventSystem.current.SetSelectedGameObject(firstButtonbutton);       // set the starting button as the selected game object

    }
    
    void OnDisable()
    {
        input.MoveSelectionEvent -= HandleMoveSelection;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void HandleMoveSelection(Vector2 direction)
    {
        // move the selection
        //var currentIndex = uiButtons.IndexOf(EventSystem.current.currentSelectedGameObject);
        //EventSystem.current.SetSelectedGameObject(null);                    //clear the currently selected game object
        //EventSystem.current.SetSelectedGameObject(firstButtonbutton);       // set the starting button as the selected game object
        
        
    }
    
    
}
