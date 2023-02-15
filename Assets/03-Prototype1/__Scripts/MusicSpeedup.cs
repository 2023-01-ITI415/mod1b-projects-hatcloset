using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpeedup : MonoBehaviour
{
    [Header("Inscribed")]
    public AudioSource audioSource;
    public AudioClip audioIntro;
    public GameObject player;
    public GameObject lava;
    public float MinPos = 14;
    public float MaxPos = 16;

    void Start()
    {
        // Set initial pitch of song
        audioSource.pitch = 1.00f;
        // Play the intro into the loop
        audioSource.PlayOneShot(audioIntro);
        audioSource.PlayScheduled(AudioSettings.dspTime + audioIntro.length);
    }

    void FixedUpdate()
    {
        // Detect distance between player and lava
        Vector2 playerpos = player.transform.position;
        Vector2 lavapos = lava.transform.position;
        if (playerpos.y < lavapos.y + MinPos) PitchUp();
        if (playerpos.y > lavapos.y + MaxPos) PitchDown();
    }

    void PitchUp()
    {
        // Return if the pitch is correct
        if (audioSource.pitch == 1.08f) return;
        if (audioSource.pitch < 1.08f)
        {
            audioSource.pitch += 0.0025f;
        }
    }

    void PitchDown()
    {
        // Return if the pitch is correct
        if (audioSource.pitch == 1.00f) return;
        if (audioSource.pitch > 1.00f)
        {
            audioSource.pitch -= 0.0025f;
        }
    }
}
