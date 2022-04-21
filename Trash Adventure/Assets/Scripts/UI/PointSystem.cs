using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static PointSystem instance;

    public Text Points;
    public Text Time;

    int pointsCounter = 0;
    public int collectedPoints = 0;

    public Text highscore;

    public int totalTime = 9000;
    public int timeRemaining;

    private void Awake()
    {
        instance = this;
        timeRemaining = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        CountPoints();
        Points.text = "Points: " + pointsCounter.ToString();
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
        Time.text  = "Time: " + (timeRemaining / 50).ToString();
    }

    void FixedUpdate()
    {
        timeRemaining = timeRemaining - 1;
    }
    
    public void addPoints(int a)
    {
        collectedPoints = collectedPoints + a;
    }

    public void CountPoints()
    {
        if(collectedPoints > 0)
        {
            for(int i = 0; collectedPoints > i;collectedPoints--)
            {
                pointsCounter++;
            } 
            SetHighScore(); 
        }
    }

    void SetHighScore()
    {
        if(pointsCounter > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",pointsCounter);  
        }

    }

    public void endOfLevelTime()
    {
        collectedPoints = collectedPoints + (timeRemaining / 5);
    }

}