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
        ClearAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Levelin loppu-menussa
    public void NextLevelTutorial()
    {
        ClearAll();
        SceneManager.LoadScene("level 1");
    }
    public void NextLevel1()
    {
        ClearAll();
        SceneManager.LoadScene("level 2");
    }
    public void NextLevel2()
    {
        ClearAll();
        SceneManager.LoadScene("level 3");
    }
    public void NextLevel3()
    {
        ClearAll();
        SceneManager.LoadScene("level 4");
    }
    public void TryAgainTutorial()
    {
        ClearAll();
        SceneManager.LoadScene("tutorial");
    }
    public void TryAgain1()
    {
        ClearAll();
        SceneManager.LoadScene("level 1");
    }
    public void TryAgain2()
    {
        ClearAll();
        SceneManager.LoadScene("level 2");
    }
    public void TryAgain3()
    {
        ClearAll();
        SceneManager.LoadScene("level 3");
    }
    public void TryAgain4()
    {
        ClearAll();
        SceneManager.LoadScene("level 4");
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
        ClearAll();
        SceneManager.LoadScene("tutorial");
        Time.timeScale = 1;
    }
    public void LevelOne()
    {
        ClearAll();
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1;
    }
    public void LevelTwo()
    {
        ClearAll();
        SceneManager.LoadScene("level 2");
        Time.timeScale = 1;
    }
    public void LevelThree()
    {
        ClearAll();
        SceneManager.LoadScene("level 3");
        Time.timeScale = 1;
    }
    public void LevelFour()
    {
        ClearAll();
        SceneManager.LoadScene("level 4");
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

    public void ClearAll()
    {
        CollectableTrash.CollectedPlastics = 0;
        CollectableTrash.CollectedLids = 0;
        CollectableTrash.CollectedPizzaSlices = 0;
        CollectableTrash.CollectedMeals = 0;
        CollectableTrash.CollectedBios = 0;
        CollectableTrash.CollectedCardboards = 0;
        CollectableTrash.CollectedCoffeeMugTrashes = 0;
        CollectableTrash.CollectedMetals = 0;
        SpawnTrash.SpawnCount = 0;
    }
}
