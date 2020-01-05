using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject RestartButton;
    public GameObject StartText;

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("restartButtonActive", restartDelay);
        }
    }

    private void FixedUpdate()
    {
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            startButtonDeactive();
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


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
