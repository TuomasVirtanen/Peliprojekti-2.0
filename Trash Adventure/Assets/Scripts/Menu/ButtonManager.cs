using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject GameOverSetActive;

    // Main menussa:
    public void QuitGame()
    {
        Debug.Log("Game has shutdown");
        Application.Quit();
    }

    // Game over menussa:
    public void TryAgain()
    {
        GameOverSetActive.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    // Levelin loppu-menussa
    public void NextLevel()
    {
        
    }

    // Pause menussa:
    public void Continue()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
    }

    // Tason valinta
    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
        Time.timeScale = 1;
    }
    public void LevelOne()
    {
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1;
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("level 2");
        Time.timeScale = 1;
    }

    // Yleiset
    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
    }
}
