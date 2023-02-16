using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDespawn : MonoBehaviour
{
    public Transform lavaPos;
    public float bottomY;

    void FixedUpdate()
    {
        bottomY = lavaPos.position.y - 10;
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
