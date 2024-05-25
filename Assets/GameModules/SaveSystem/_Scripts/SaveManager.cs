using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO; 

public class SaveManager : MonoBehaviour
{
    #region Region SingletonSaveManager
        private static SaveManager instance;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(instance.gameObject);
            }
            else
            {
                instance = this;
            }
        }
    #endregion
    
    #region Region List<ISaveManager> saveManagerList
        private List<ISaveManager> saveManagerList;

        private List<ISaveManager> FindSaveManagers()
        {
            IEnumerable<ISaveManager> saveManagers = FindObjectsOfType<MonoBehaviour>().OfType<ISaveManager>();
            return new List<ISaveManager>(saveManagers);
        }
    #endregion

    [SerializeField] private string fileName = "data.json";
    private GameData gameData;
    private FileDataHandler dataHandler;

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        Debug.Log("Save path = " + Application.persistentDataPath + fileName);
        saveManagerList = FindSaveManagers();
        LoadGame();
    }

    private void StartNewGame()
    {
        gameData = new GameData();
    }

    /*
     * Save and Load section
     */
    private void SaveGame()
    {
        // collect data from all sources
        foreach (ISaveManager saveManager in saveManagerList )
        {
            saveManager.SaveData(ref gameData);
        }
        
        dataHandler.Save(gameData);     // saves data to files
        
        Debug.Log("Data saved to files(s)");
    }
    
    
    public void LoadGame()
    {
        gameData = dataHandler.Load();  // Load data from save files
        
        if (this.gameData == null)
        {
            StartNewGame();
        }
        
        foreach (ISaveManager saveManager in saveManagerList )
        {
            saveManager.LoadData(gameData);
            if (gameData != null)
            {
                Debug.Log("Data loaded from files(s)");
                //Debug.Log("Data Load: score " + gameData.score);
                //Debug.Log("Data Load: lives " + gameData.lives); 
            }
        }
    }

    public void SaveCurrentGame()
    {
        SaveGame();
    }

    

    /*
     * Application management section
     */
    private void OnApplicationQuit()
    {
        // this is a design choice you maye or may not
        // want to save on exit.
        SaveCurrentGame();
    }
}
