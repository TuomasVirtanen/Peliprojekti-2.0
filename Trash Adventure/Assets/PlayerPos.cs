using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        try
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            transform.position = gm.CheckPointPos;
        }
        catch
        {
            Debug.Log("no gm on the scene");
        }
    }
}
