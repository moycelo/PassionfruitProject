using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen instance;
    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);

    }
    public void Show()
    {
        Time.timeScale = 0f;//freezes the game when game over screen is active
        gameObject.SetActive(true);

    }
}