using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectChecker : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if(SpawnTrash.SpawnCount > 1)
        {
            SpawnTrash.SpawnCount--;
        }
        else
        {
            SceneManager.LoadScene("LevelEndingMenu");
        }
    }
}
