
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    
    public static Difficulty instance;

    [SerializeField] private float baseSpeed = 6f; // Starting speed of the game, can be adjusted in the inspector
    [SerializeField] private float maxSpeed = 15f; // Maximum speed the game can reach, can be adjusted in the inspector
    [SerializeField] private float speedIncreaseRate = 0.5f; // Rate at which the speed increases over time, can be adjusted in the inspector
    [SerializeField] private float scoreThreshold = 150f;
    public float currentSpeed;// Current speed of the game
    private float nextThreshold; //next score threshold for increasing speed

    void Awake()
    {
        instance = this;
        currentSpeed = baseSpeed; //initialized speed to current speed at start
        nextThreshold = scoreThreshold;
    }

    void Update()
    {
        if (ScoreCounter.isGameOver) return;

        if (ScoreCounter.scoreValue >= nextThreshold)
        {
            nextThreshold += scoreThreshold;
            currentSpeed = Mathf.Min(currentSpeed + speedIncreaseRate, maxSpeed); //sets next threshold by 150
        }
    }
        
}
