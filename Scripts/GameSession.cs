using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* A class that is responsible for the proper course of the game */
public class GameSession : MonoBehaviour
{
    // Config Params
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] Text scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    int numberOfBalls = 0;

    // Status
    int currentScore = 0;

    /* This is the first function that run (this class is singleton) */
    private void Awake() 
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    /* A function that adds points to the overall score */
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    /* A function that restarts the game */
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    /* A function that is just for testing and playing alone */
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled; 
    }

    /* A function that return the number of balls in the game */
    public int GetNumberOfBalls(){ return numberOfBalls; }

    /* A function that add ball */
    public void AddBall() 
    { 
        numberOfBalls++; 
    }

    /* A function that decrease ball */
    public void DecBall()
    {
        numberOfBalls--;
    }
}
