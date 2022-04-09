using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    private Vector3 teleportExit;
    void Awake()
    {
        teleportExit = GameObject.Find("teleportExit").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Teleporter")
        {
            transform.position = teleportExit;
        }
    }
}
