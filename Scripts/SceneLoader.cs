using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* A class that is responsible for switching between the different scenes */
public class SceneLoader : MonoBehaviour {

    /* A function that moves to the next scene */
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /* A function that loads the start scene */
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    /* A function that goes out of the game */
    public void QuitGame()
    {
        Application.Quit();
    }

    /* A fuction that loads the start neptune scene */
    public void LoadStartNeptune()
    {
        SceneManager.LoadScene("Start Neptune");
    }

    /* A fuction that loads the start uranus scene */
    public void LoadStartUranus()
    {
        SceneManager.LoadScene("Start Uranus");
    }

    /* A fuction that loads the start uranus scene */
    public void LoadStartSaturn()
    {
        SceneManager.LoadScene("Start Saturn");
    }


}
