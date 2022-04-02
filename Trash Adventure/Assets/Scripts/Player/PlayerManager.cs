using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    Vector3 Spawnpoint = new Vector3(-25, -2, 0);
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;

    void Awake()
    {
    characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
    GameObject player = Instantiate(playerPrefabs[characterIndex], Spawnpoint, Quaternion.identity);
    VCam.m_Follow = player.transform;
    }
}
