using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Easy");
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync("CreditsPage");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Retry()
    {
        Time.timeScale = 1f;//unfreezes the game when retrying
        ScoreCounter.isGameOver = false;
        ScoreCounter.scoreValue = 0;
        SceneManager.LoadScene("Easy");
    }
    public void DifficultySelection()
    {
        SceneManager.LoadSceneAsync("Difficulty");
    }
    public void Easy()
    {
        SceneManager.LoadSceneAsync("Easy");
    }
    public void Easier()
    {
        SceneManager.LoadSceneAsync("Easier");
    }

    //Hello Sirs
}
