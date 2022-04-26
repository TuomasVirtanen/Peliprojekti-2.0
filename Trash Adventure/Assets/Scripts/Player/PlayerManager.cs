using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;
    private GameMaster gm;

    void Start()
    {
    Application.targetFrameRate = 45;
    characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        try
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            GameObject player = Instantiate(playerPrefabs[characterIndex], gm.CheckPointPos, Quaternion.identity);
            VCam.m_Follow = player.transform;
        }
        catch
        {
            Vector3 spawnpoint = GameObject.Find("Spawnpoint").transform.position;
            GameObject player = Instantiate(playerPrefabs[characterIndex], spawnpoint, Quaternion.identity);
            VCam.m_Follow = player.transform;
        }    
    }
}
