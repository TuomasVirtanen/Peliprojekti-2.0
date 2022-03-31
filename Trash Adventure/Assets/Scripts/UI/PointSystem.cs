using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static PointSystem instance;

    public Text Points;
    int pointsCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pointsCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Points.text = pointsCounter.ToString();
        
    }

    public void addPoints(int a)
    {
        pointsCounter = pointsCounter + a;
    }
}
