using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpeedup : MonoBehaviour
{
    [Header("Inscribed")]
    public AudioSource audioSource;
    public GameObject player;
    public GameObject lava;
    public float MinProx;
    public float MaxProx;

    void Start()
    {
        // Set initial pitch of song
        audioSource.pitch = 1.00f;
    }

    void FixedUpdate()
    {
        if (player.transform.position.y < lava.transform.position.y + MinProx)
        {
            PitchUp();
        }
        if (player.transform.position.y > lava.transform.position.y + MaxProx)
        {
            PitchDown();
        }
    }

    void PitchUp()
    {

        if (audioSource.pitch == 1.08f) return;
        if (audioSource.pitch < 1.08f)
        {
            audioSource.pitch += 0.005f;
        }
    }
    void PitchDown()
    {
        if (audioSource.pitch == 1.00f) return;
        if (audioSource.pitch > 1.00f)
        {
            audioSource.pitch -= 0.005f;
        }
    }
}
