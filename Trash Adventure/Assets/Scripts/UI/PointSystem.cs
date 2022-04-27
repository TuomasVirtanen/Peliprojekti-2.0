using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    Scene m_Scene;
    string sceneName;

    private void Awake()
    {
        instance = this;
        timeRemaining = totalTime;


    }

    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        PlayerPrefs.SetString("lastSceneName", sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        CountPoints();
        Points.text = "Points: " + pointsCounter.ToString();
        highscore.text = "Highscore: " + PlayerPrefs.GetInt(sceneName).ToString();
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

        

        for(int i = 0; collectedPoints > i;collectedPoints--)
        {
            pointsCounter++;
        } 
        SetHighScore(sceneName); 
        if(pointsCounter > PlayerPrefs.GetInt("lastLevelPoints")) {PlayerPrefs.SetInt("lastLevelPoints",pointsCounter);}
    }

    void SetHighScore(string level)
    {
        if(pointsCounter > PlayerPrefs.GetInt(level))
        {
            PlayerPrefs.SetInt(level,pointsCounter);  
        }

    }

    public void endOfLevelTime()
    {
        collectedPoints = collectedPoints + (timeRemaining / 5);
    }

}