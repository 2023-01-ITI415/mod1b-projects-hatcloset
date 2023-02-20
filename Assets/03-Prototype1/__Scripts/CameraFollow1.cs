using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    static private CameraFollow1 S;
    static public Transform Target;
    static public Transform BadTarget;

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
        Vector3 destination = Vector3.zero;
        if (BadTarget.transform.position.y + 10 > destination.y)
        {
            destination = BadTarget.transform.position;
        } else destination = Target.transform.position;
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
