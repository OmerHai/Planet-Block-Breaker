using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class responsible for the level itself (number of breakable blocks, pass a level when there are no more blocks) */
public class Level : MonoBehaviour
{
    // Stats
    int breakableBlocks;

    // Cached reference
    SceneLoader sceneLoader;

    private void Start() 
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /* A function that counts the number of breakable blocks */
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    /* Function that checks when the level ends (when there are no more breakable blocks) */
    public void BlockDestroy() 
    {
        breakableBlocks--;
        if(breakableBlocks <=0 )
        {
            sceneLoader.LoadNextScene();
        }
    }
}
