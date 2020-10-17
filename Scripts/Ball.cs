using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A script that belongs to the game ball */
public class Ball : MonoBehaviour
{
    // Config Params
    [Header("Paddle")]
    [SerializeField] Paddle paddle1;

    [Header("Ball move")]
    [SerializeField] float xPush = 2f; // A variable that shows how many units the ball moves on the X-axis while pressing for the first time
    [SerializeField] float yPush = 15f;// A variable that shows how many units the ball moves on the Y-axis while pressing for the first time
    [SerializeField] float randomFactor = 0.2f; // A variable that adds some randomness to the movement of the ball to prevent the ball's bug moving from side to side

    [Header("Sound")]
    [SerializeField] AudioClip[] ballSounds;
    
    // State
    Vector2 paddleToBallVector;// A vector that is the distance between the ball and the paddle(thus allowing the ball to be stuck to the paddle at first)
    bool hasStarted = false; // Checking if the game started or not
    GameSession gameSession;

    // Cached Component References
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    /* Start is called before the first frame update */
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.AddBall();
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        if(gameSession.GetNumberOfBalls() > 1) 
        {
            hasStarted=true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
        paddleToBallVector = transform.position - paddle1.transform.position;

    }

    /* Update is called once per frame */
    void Update()
    {
        // Runs only if the game has not started
        if(!hasStarted) 
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }  
    }

    /* A function that attaches the ball to the paddle as long as the game has not started */
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }

    /* Function that moves the ball according to the variables: xPush, yPush, when you click the mouse for the first time */
    private void LaunchOnMouseClick()
    {
        // Runs when the user clicks the mouse
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    /* A function he only wanted when the ball collided with something */
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 veloctyTweak = new Vector2(Random.Range(0f,randomFactor),Random.Range(0f, randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += veloctyTweak;
        }
    }
}