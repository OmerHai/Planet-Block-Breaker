using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* A class that is responsible for moving to the game over screen when the player is lose */
public class LoseCollider : MonoBehaviour
{
    // State
    GameSession gameSession;
    private void Start() 
    {
        gameSession = FindObjectOfType<GameSession>();
    }
    /* A function that is run when something passes through the object */
    private void OnTriggerEnter2D(Collider2D other) 
    {
        gameSession.DecBall();
        if(gameSession.GetNumberOfBalls() == 0)
        {
            if (SceneManager.GetActiveScene().path.Contains("Neptune"))
            {
                SceneManager.LoadScene("Game Over Neptune");
            }

            if(SceneManager.GetActiveScene().path.Contains("Uranus"))
            {
                SceneManager.LoadScene("Game Over Uranus");
            }

            if (SceneManager.GetActiveScene().path.Contains("Saturn"))
            {
                SceneManager.LoadScene("Game Over Saturn");
            }
        }
    }
}
