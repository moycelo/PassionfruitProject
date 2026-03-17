using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    public static float scoreValue = 0;
    public int coinCount = 0;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Awake()
   {
       if (instance == null)
           instance = this;
       else
           Destroy(gameObject);
   }

    // Update is called once per frame
    void Update()
    {
        scoreValue += Time.deltaTime * 10f; // Increment score based on time
        scoreText.text = Mathf.FloorToInt(scoreValue).ToString("D8"); //00000000 counter

        coinText.text = "Coins: " + coinCount.ToString();
    }
}
