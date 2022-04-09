using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;

    void Start()
    {
    characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
    Vector3 spawnpoint = GameObject.Find("Spawnpoint").transform.position;
    GameObject player = Instantiate(playerPrefabs[characterIndex], spawnpoint, Quaternion.identity);
    VCam.m_Follow = player.transform;
    }
}
