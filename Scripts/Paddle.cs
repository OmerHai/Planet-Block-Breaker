using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A script that contains the paddle */
public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float MaxX = 15f;

    // Cached reference
    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(),minX, MaxX);
        transform.position = paddlePos;
    }

    /* A function that returns the position on the X-axis depends on whether it runs automatically or with the click of a mouse */
    private float GetXPos()
    {
        if(gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }

        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
