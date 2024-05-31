using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputReader input;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject buildMenu;
    
    void Start()
    {
        input.PauseMenuEvent += HandlePauseMenu;
        input.ResumeEvent += HandleResume;
        input.BuildMenuEvent += HandleBuildMenu;
        input.BuildMenuCloseEvent += HandleBuildMenuClose;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void HandlePauseMenu()
    {
        pauseMenu.SetActive(true);
        //Time.timeScale = 0;
    }
    
    void HandleResume()
    {
        pauseMenu.SetActive(false);
        //Time.timeScale = 1;
    }
    
    
    void HandleBuildMenu()
    {
        buildMenu.SetActive(true);
    }
    
    void HandleBuildMenuClose()
    {
        buildMenu.SetActive(false);
    }
}
