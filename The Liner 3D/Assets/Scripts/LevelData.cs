using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


[System.Serializable]
public class LevelData
{
    public int levelIndex;

    public LevelData()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
}
