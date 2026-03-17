using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    public static bool isGameOver = false;
    public static float scoreValue = 0;
    public int coinCount = 0;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Awake()
   {
        if (instance == null) // Check if an instance already exists
        {
        instance = this; // Set the instance to this object
        isGameOver = false; // Reset game over state
        scoreValue = 0; // Reset score value
       }

        else
            Destroy(gameObject);
   }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return; // Stop updating score if game is over
        scoreValue += Time.deltaTime * 10f; // Increment score based on time
        scoreText.text = Mathf.FloorToInt(scoreValue).ToString("D8"); //00000000 counter

        coinText.text = "Coins: " + coinCount.ToString();


    }   
}
