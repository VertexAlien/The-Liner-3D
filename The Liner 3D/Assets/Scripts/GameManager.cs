using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject RestartButton;
    public GameObject StartText;
    public GameObject EndPanel;
    public GameObject Timer;

    bool gameHasEnded = false;
    public float restartDelay = 1f;


    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            startButtonDeactive();
        }
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
    }
    
    public void startButtonDeactive()
    {
        StartText.SetActive(false);
        Timer.SetActive(true);
    }

    public void LevelEnd()
    {
        EndPanel.SetActive(true);
        Destroy(Timer);

    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
