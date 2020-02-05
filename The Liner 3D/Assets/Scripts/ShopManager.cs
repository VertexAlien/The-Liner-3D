using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public string choosenplayer;

    public void LoadLevel()
    {
        LevelData data = SaveSystem.LoadLevel();

        SceneManager.LoadScene(data.levelIndex);
    }

    public void IsCube()
    {
        choosenplayer = "CUBE";
        ConfirmToLoad();
    }

    public void IsBurger()
    {
        choosenplayer = "BURGER";
        ConfirmToLoad();
    }

    public void IsClock()
    {
        choosenplayer = "CLOCK";
        ConfirmToLoad();
    }

    public void IsOven()
    {
        choosenplayer = "OVEN";
        ConfirmToLoad();
    }

    void ConfirmToLoad()
    {
        PlayerPrefs.SetString("choosenplayer", choosenplayer);
        LoadLevel();
    }


}
