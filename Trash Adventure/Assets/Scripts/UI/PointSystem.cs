using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static PointSystem instance;

    public Text Points;
    
    int pointsCounter = 0;
    public int collectedPoints = 0;

    public Text highscore = PlayerPrefs.GetInt("HighScore").ToString();

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Points.text = pointsCounter.ToString();
    }

    public void AddPoints(int a)
    {
        collectedPoints = collectedPoints + a;
    }

    public void CountPoints(int a)
    {
        for(int i = 0; collectedPoints > i;collectedPoints--)
        {
            pointsCounter++;
        } 
        SetHighScore(); 
    }

    void SetHighScore()
    {
        if(pointsCounter > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore"pointsCounter);  
        }
    void GetHighScore()
    {
        highscore = PlayerPrefs.GetInt("HighScore").ToString();
    }




}
