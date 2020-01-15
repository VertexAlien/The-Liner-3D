using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject Player;
    public GameObject TimerTrigger;
    public GameObject Filler;
    public GameObject Text;
    public float maxTime = 10;

    Image timerBar;
    Text timetext;
    float timeleft;

    void Start()
    {
        timerBar = Filler.GetComponent<Image>();
        timetext = Text.GetComponent<Text>();
        timeleft = maxTime;
    }

    void Update()
    {
        timeCounter();
    }

    void timeCounter()
    {
        if (timeleft > 0)
        {
            timeleft -= 1 * Time.deltaTime;
            if(timeleft <= 7 && timeleft >= 4)
            {
                timetext.color = Color.yellow;
                timerBar.color = Color.yellow;
            }
            else if (timeleft <= 3)
            {
                timetext.color = Color.red;
                timerBar.color = Color.red;
            }
            timetext.text = timeleft.ToString("0");
            timerBar.fillAmount = timeleft / maxTime;
        }
        
        else
        {
            TimerTrigger.transform.position = Player.transform.position;
            TimerTrigger.SetActive(true);
            
        }
    }
}
