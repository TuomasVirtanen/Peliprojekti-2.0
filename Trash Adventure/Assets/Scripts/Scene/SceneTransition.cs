using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    //On collision switches scene to a new one
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
            
            PointSystem.instance.endOfLevelTime();
        }
    }
}
