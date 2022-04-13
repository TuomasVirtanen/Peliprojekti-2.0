using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Main menussa:
    public void PlayGame()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void QuitGame()
    {
        Debug.Log("Game has shutdown");
        Application.Quit();
    }

    // Game over menussa:
    public void TryAgain()
    {
        SceneManager.LoadScene("tutorial");
    }
    
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
