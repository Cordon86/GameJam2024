using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class GameData
{
    public int score;
    public int lives;

    public GameData()
    {
        this.score = 0;
        this.lives = 3; // #SorryNotSorry no cats
    }
}
