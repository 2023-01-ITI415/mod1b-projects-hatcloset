using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDespawn : MonoBehaviour
{
    public GameObject lava;
    public float lavaPos;

    void Update()
    {
        lavaPos = lava.transform.position.y;
        if (this.transform.position.y < lavaPos)
        {
            Destroy(this);
        }
    }
}
