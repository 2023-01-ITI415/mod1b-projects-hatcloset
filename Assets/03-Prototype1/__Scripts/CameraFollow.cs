using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    static private CameraFollow S;
    public GameObject POI;
    public GameObject Lava;

    [Header("Inscribed")]
    public float easing = 0.05f;
    public Vector2 minY = Vector2.zero;

    [Header("Dynamic")]
    public float camX;
    public float camZ;

    void Awake()
    {
        S = this;
        camX = this.transform.position.x;
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 destination = POI.transform.position;
        if (Lava.transform.position.y + 10 > destination.y)
        {
            POI = Lava;
        }
        destination = Vector3.Lerp(transform.position, destination, easing);
        // Limit the minimum values of destination.y
        destination.y = Mathf.Max(minY.y, destination.y);
        // Force destination.x and destination.z to keep the vertical scrolling still
        destination.x = camX;
        destination.z = camZ;
        // Set the camera to the destination
        this.transform.position = destination;
    }
}
