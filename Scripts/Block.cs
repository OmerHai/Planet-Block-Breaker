using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A script for the blocks in the game */
public class Block : MonoBehaviour
{
    // Config Params
    [Header("Effects")]
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] HitSprites;
    [SerializeField] Ball ball;
    [SerializeField] Ball fireBall;

    // Cached reference
    Level level;
    Paddle paddle;

    // State variables
    int timesHit;

    /* A function that run when the object starts */
    private void Start() 
    {
        CountBreakableBlocks();
    }

    /* A function that counts how many breakable blocks there are in a level */
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        switch(tag) {
            case "Breakable":
                level.CountBlocks();
            break;

            case "NewBall":
                level.CountBlocks();
            break;

            case "FireBall":
                level.CountBlocks();
            break;
            case "BigBall":
                level.CountBlocks();
            break;
            case "SmallBall":
                level.CountBlocks();
            break;
            case "BigPaddle":
                level.CountBlocks();
            break;
        }
    }

    /* A function that run only when something collided with a block */
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(tag == "Unbreakable")
        {
            if(collision.gameObject.tag == "FireBall")
            {
                timesHit = 10;
                HandleHit();
            }
        }

        if (tag == "Breakable" || tag=="NewBall" || tag=="FireBall" || tag == "BigBall" || tag=="SmallBall" || tag == "BigPaddle" || tag == "SmallPaddle")
        {
            HandleHit();
        }
    }

    /* A function that is responsible for handling the block when it collides */
    private void HandleHit()
    {
        timesHit++;
        int maxHits = HitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    

    /* Function that shows the block after the additional hit (with cracks) */
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(HitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }    
    }


    /* A function responsible for destroying the block */
    public void DestroyBlock()
    {
        if(tag == "NewBall")
        {
            Instantiate(ball, transform.position, Quaternion.identity);
        }
        if (tag == "BigBall")
        {
           Ball[] balls = FindObjectsOfType<Ball>();
           for(int i = 0; i < balls.Length; i++)
           {
                float scaleX = balls[i].gameObject.transform.localScale.x * 1.2f;
                float scaleY = balls[i].gameObject.transform.localScale.y * 1.2f;
                Vector3 vector3 = new Vector3(scaleX, scaleY, 1f);
                balls[i].gameObject.transform.localScale = vector3;
           }
        }

        if (tag == "SmallBall")
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            for (int i = 0; i < balls.Length; i++)
            {
                float scaleX = balls[i].gameObject.transform.localScale.x * 0.8f;
                float scaleY = balls[i].gameObject.transform.localScale.y * 0.8f;
                Vector3 vector3 = new Vector3(scaleX, scaleY, 1f);
                balls[i].gameObject.transform.localScale = vector3;
            }
        }

        if (tag == "BigPaddle")
        {
            paddle = FindObjectOfType<Paddle>();
            float scaleX = paddle.gameObject.transform.localScale.x * 1.2f;
            float scaleY = paddle.gameObject.transform.localScale.y * 1.2f;
            Vector3 vector3 = new Vector3(scaleX, scaleY, 1f);
            paddle.gameObject.transform.localScale = vector3;
        }

        if (tag == "SmallPaddle")
        {
            paddle = FindObjectOfType<Paddle>();
            float scaleX = paddle.gameObject.transform.localScale.x * 0.8f;
            float scaleY = paddle.gameObject.transform.localScale.y * 0.8f;
            Vector3 vector3 = new Vector3(scaleX, scaleY, 1f);
            paddle.gameObject.transform.localScale = vector3;
        }

        if(tag == "FireBall")
        {
            Ball ball = Instantiate(fireBall, transform.position, Quaternion.identity);  
        }
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroy();
        TriggerSparklesVFX();
    }

    /* A function that makes a sound of breaking */
    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    /* A function responsible for the visual effect of breaking the block */
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
