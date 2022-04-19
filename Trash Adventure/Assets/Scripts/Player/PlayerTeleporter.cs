using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    //define teleportExits
    private Vector3 teleportExit;
    private Vector3 teleportExit2;

    //on awake, find teleportexit gameobject positions
    void Awake()
    {
        teleportExit = GameObject.Find("teleportExit").transform.position;
        teleportExit2 = GameObject.Find("teleportExit2").transform.position;
    }

    //on collision transform position to either teleport exit 1 or 2
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Teleporter")
        {
            transform.position = teleportExit;
        }

        if (collision.tag == "Teleporter2")
        {
            transform.position = teleportExit2;
        }
    }
}
