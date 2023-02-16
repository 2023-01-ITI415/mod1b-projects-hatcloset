using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
    private float lavaSpeed;
    public Transform playerPos;

    void Start()
    {
        lavaSpeed = 0.0f;
    }

    void FixedUpdate()
    {
        if(playerPos.position.y != 0)
        {
            if (lavaSpeed < 0.07) lavaSpeed += 0.00003f;
            Vector3 pos = this.transform.position;
            pos.y += lavaSpeed;
            this.transform.position = pos;
        }
    }
}
