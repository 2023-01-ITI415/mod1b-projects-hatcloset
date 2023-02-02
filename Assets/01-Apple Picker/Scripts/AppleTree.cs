using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Chance that the AppleTree will change directions
    public float leftAndRightEdge = 10f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    void Start()
    {
        // Start dropping Apples
//b
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed); // Move Right
        } else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed); // Move left
        }
    }
}
