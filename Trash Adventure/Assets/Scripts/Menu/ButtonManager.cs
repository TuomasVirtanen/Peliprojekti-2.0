using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Main menussa:
    public void QuitGame()
    {
        Debug.Log("Game has shutdown");
        Application.Quit();
    }

    // Game over menussa:
    public void TryAgain()
    {
        SceneManager.UnloadSceneAsync("GameOverMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    // Tason valinta
    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void LevelOne()
    {
        SceneManager.LoadScene("level 1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("level 2");
    }
    public void GoBack()
    {
        SceneManager.UnloadSceneAsync("LevelSelection");
    }

    // Yleiset
    public void LevelSelection()
    {
        SceneManager.LoadSceneAsync("LevelSelection", LoadSceneMode.Additive);
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
