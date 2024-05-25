using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ISaveManager
{
    #region SingletonPlayerManager
    //not empty
    #endregion
    
    [SerializeField] private int score;
    [SerializeField] private int lives;
    
    public int GetScore() => score;
    public int GetLives() => lives;

    public void LoadData(GameData gameData)
    {
        score = gameData.score;
        lives = gameData.lives;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.score = score;
        gameData.lives = lives;
    }
}
