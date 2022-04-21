using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MenuPoints : MonoBehaviour
{
    public TextMeshProUGUI Highscore;
    public TextMeshProUGUI Points;

    // Update is called once per frame
    void Update()
    {
        
        Points.text = "Saadut pisteet: " + PlayerPrefs.GetInt("lastLevelPoints").ToString();
        Highscore.text = "Ennatys: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
