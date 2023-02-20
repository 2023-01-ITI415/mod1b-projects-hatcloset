using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
    private float lavaSpeed;
    private float maxSpeed;
    private float checkpoint;
    public Transform playerPos;
    public AudioSource audioSource;
    public Player player;


    void Start()
    {
        audioSource.pitch = 0.94f;
        lavaSpeed = 0.0f;
        maxSpeed = 0.07f;
        checkpoint = 200;
        GameObject playerGO = GameObject.Find("Player");
        playerPos = playerGO.transform;
        player = playerGO.GetComponent<Player>();
    }

    void FixedUpdate()
    {
        if(playerPos.position.y != 0)
        {
            if (lavaSpeed < maxSpeed) lavaSpeed += 0.00003f;
            Vector3 pos = this.transform.position;
            pos.y += lavaSpeed;
            this.transform.position = pos;
        }
        if (playerPos.position.y >= checkpoint)
        {
            checkpoint += 200;
            maxSpeed += 0.0025f;
            audioSource.Play();
            if (audioSource.pitch < 1.48f) audioSource.pitch += 0.08f;
            player.multiplyScore();
        }
    }
}
