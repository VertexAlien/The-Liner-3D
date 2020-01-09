using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject RestartButton;
    public GameObject StartText;
    public GameObject EndPanel;

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
    }

    public void LevelEnd()
    {
        EndPanel.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
