using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputReader input;
    [SerializeField] private GameObject pauseMenu;
    
    void Start()
    {
        input.PauseEvent += HandlePause;
        input.ResumeEvent += HandleResume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void HandlePause()
    {
        pauseMenu.SetActive(true);
        //Time.timeScale = 0;
    }
    
    void HandleResume()
    {
        pauseMenu.SetActive(false);
        //Time.timeScale = 1;
    }
}
