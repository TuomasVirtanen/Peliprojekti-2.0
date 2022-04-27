using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectChecker : MonoBehaviour
{
    [SerializeField]
    private string levelEndingScene;
    private bool endingSceneLoaded = false;

    private void Update()
    {
        if(SpawnTrash.NothingToSpawn && endingSceneLoaded == false)
        {
            Debug.Log("ei ollu mitään spawnattavaa");
            endingSceneLoaded = true;
            PointSystem.instance.CountPoints();
            SceneManager.LoadSceneAsync(levelEndingScene, LoadSceneMode.Additive);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(SpawnTrash.SpawnCount > 1)
        {
            SpawnTrash.SpawnCount--;
        }
        else
        {
            PointSystem.instance.CountPoints();
            SceneManager.LoadSceneAsync(levelEndingScene, LoadSceneMode.Additive);
        }
    }
}
