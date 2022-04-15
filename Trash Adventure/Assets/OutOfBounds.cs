using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public GameObject GameOverSetActive;

    void Awake()
    {
        GameOverSetActive.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameOverSetActive.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
