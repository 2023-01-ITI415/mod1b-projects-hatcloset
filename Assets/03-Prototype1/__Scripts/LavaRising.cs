using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
    private float lavaSpeed;

    void Start()
    {
        lavaSpeed = 0.001f;
    }

    void FixedUpdate()
    {
        if (lavaSpeed < 0.04) lavaSpeed += 0.00005f;
        Vector3 pos = this.transform.position;
        pos.y += lavaSpeed;
        this.transform.position = pos;
    }
}
