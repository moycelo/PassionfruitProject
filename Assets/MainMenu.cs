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
}
