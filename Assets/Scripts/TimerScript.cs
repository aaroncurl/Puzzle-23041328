using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    //public gameManager gm;

    public TMP_Text TimerText;
    public float timeRemaining = 10;
    public float timetotal;
    public bool timerIsRunning = false;
    public bool frozen = false;

    private void Start()
    {
        // Starts the timer automatically
        PlayerPrefs.SetInt("Qs", 0);
        timerIsRunning = true;
        //gm.gameStarted = true;
        timetotal = timeRemaining;
    }

    void Update()
    {
        //This checks if time is running then start adding time else stop time
        if (!frozen)
        {
            if (timerIsRunning)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining -= Time.deltaTime;
                    TimerText.text = timeRemaining.ToString();
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
            }
            //This increments the time on every wrong ans
            if (PlayerPrefs.GetInt("Inc", 0) == 1)
            {
                timeRemaining += 5;
                timetotal += 5;
                PlayerPrefs.SetInt("Inc", 0);

            }
            //This function displays the time in mins and secs
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
