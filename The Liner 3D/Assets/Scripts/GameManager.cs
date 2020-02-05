using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{

    public GameObject RestartButton;
    public GameObject StartText;
    public GameObject EndPanel;
    public GameObject Timer;
    public GameObject ShopButton;

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    private string game_id = "3436284";
    private string video_ad = "video";
    private string rewardedvideo_ad = "rewardedVideo";
    private string banner_ad = "bannerAd";

    private void Start()
    {
        Advertisement.Initialize(game_id, true);
        //StartCoroutine(ShowBannerWhenReady());
    }
    private void Update()
    {
        
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("restartButtonActive", restartDelay);
        }
    }

    
    private void restartButtonActive()
    {
        RestartButton.SetActive(true);
        Destroy(Timer);
    }
    
    public void startButtonDeactive()
    {
            StartText.SetActive(false);
            ShopButton.SetActive(false);
            Timer.SetActive(true);
    }

    public void LevelEnd()
    {
        EndPanel.SetActive(true);
        Destroy(Timer);

    }

    public void nextLevel()
    {
        //ShowVideoAd();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        //ShowVideoAd();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadShopMenu()
    {
        SaveLevel();
        //ShowVideoAd();
        SceneManager.LoadScene("Shop");
    }

    public void SaveLevel()
    {
        SaveSystem.SaveLevel();
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(banner_ad))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(banner_ad);
        
    }

    void ShowVideoAd()
    {
        if(Advertisement.IsReady(video_ad))
        {
            Advertisement.Show(video_ad);
        }
    }
}
