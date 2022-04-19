using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlow : MonoBehaviour
{
    public GameObject PlayerGlowSetActive;

    void Awake()
    {
        PlayerGlowSetActive.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DarkAreaEnter")
        {
            PlayerGlowSetActive.SetActive(true);
        }

        if (collision.tag == "DarkAreaExit")
        {
            PlayerGlowSetActive.SetActive(false);
        }
    }
}