using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool dead;
    private Rigidbody rb;
    private bool jumpStored;
    // public float xbounds = 19.5f;
    public ScoreCount scoreCount;
    public AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip deathSound;
    public AudioClip dashSound;
    public float scoreMultiply;

    void Start()
    {
        scoreMultiply = 1f;
        dead = false;
        // Find the Rigidbody
        rb = GetComponent<Rigidbody>();
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCount");
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCount = scoreGO.GetComponent<ScoreCount>();
    }
    void Update()
    {
        if (!Player.dead)
        {
            // Adjust directional movement for the player
            float dirX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(dirX * 10f, rb.velocity.y);

            // Jump once when W or Up are pressed
            if (Input.GetButtonDown("Duck"))
            {
                rb.velocity = new Vector2(rb.velocity.x, -40f);
                audioSource.PlayOneShot(dashSound);
            }
            if (jumpStored == true)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.velocity = new Vector2(rb.velocity.x, 10f);
                    jumpStored = false;
                    audioSource.PlayOneShot(dashSound);
                }
            }
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("JumpGround"))
        {
            jumpStored = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(coinSound);
            scoreCount.score += (int)(100f * scoreMultiply);
            HighScoreProto.TRY_SET_HIGH_SCORE(scoreCount.score);
        }
        if (other.gameObject.CompareTag("Lava"))
        {
            Player.dead = true;
            audioSource.PlayOneShot(deathSound);
            
        }
    }

    public void multiplyScore()
    {
        scoreMultiply += 0.1f;
    }
}
