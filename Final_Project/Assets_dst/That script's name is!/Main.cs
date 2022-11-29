using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Main : MonoBehaviour
{
    public Text timer;
    public Text Score;
    float dateTime;
    static public Main S;
    [Header("Set in Inspector")]
    float timeForEachLevel = 240;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        dateTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ShowTime();
        UpdateScore();
    }
    void ShowTime()
    {
        int timePassed = (int)(Time.time - dateTime);
        int timeLeft = (int)(timeForEachLevel - timePassed);
        int minutes = timeLeft / 60;
        int seconds = timeLeft % 60;
        DateTime time = DateTime.Now;
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateScore()
    {
        Score.text = "Score: " + score; 
    }
}
