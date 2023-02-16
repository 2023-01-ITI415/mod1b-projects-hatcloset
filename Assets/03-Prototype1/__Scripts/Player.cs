using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool jumpStored;
    // public float xbounds = 19.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
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
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("JumpGround"))
        {
            jumpStored = true;
        }
    }
}
