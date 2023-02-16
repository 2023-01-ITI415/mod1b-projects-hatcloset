using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool dead = false;
    private Rigidbody rb;
    private bool jumpStored;
    // public float xbounds = 19.5f;
    public ScoreCount scoreCount;
    public AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip deathSound;

    void Start()
    {
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
            if (jumpStored == true)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.velocity = new Vector2(rb.velocity.x, 10f);
                    jumpStored = false;
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
            scoreCount.score += 100;
            HighScoreProto.TRY_SET_HIGH_SCORE(scoreCount.score);
        }
        if (other.gameObject.CompareTag("Lava"))
        {
            Player.dead = true;
            audioSource.PlayOneShot(deathSound);
        }
    }
}
