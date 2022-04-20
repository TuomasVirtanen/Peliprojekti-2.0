using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTeleporter : MonoBehaviour
{
    //define teleportExits
    private Vector3 teleportExit;
    private Vector3 teleportExit2;
    [SerializeField] private AudioSource teleport;

    //on awake, find teleportexit gameobject positions
    void Awake()
    {
        try
        {
            teleportExit = GameObject.Find("teleportExit").transform.position;
            teleportExit2 = GameObject.Find("teleportExit2").transform.position;
        }
        catch (NullReferenceException) 
        {
         Debug.Log("No teleporter 1 or 2 in level");
        }
    }

    //on collision transform position to either teleport exit 1 or 2
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Teleporter")
        {
            teleport.Play();
            transform.position = teleportExit;
        }

        if (collision.tag == "Teleporter2")
        {
            teleport.Play();
            transform.position = teleportExit2;
        }
    }
}
