using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pacer : MonoBehaviour
{
    [Header("Inscribed")]
    public AudioSource audioSource;
    public AudioSource alarmSource;
    public AudioClip audioIntro;
    public GameObject player;
    public GameObject lava;
    public float MinPos = 14;
    public float MaxPos = 16;

    void Start()
    {
        // Set initial pitch and volume of song
        audioSource.pitch = 1.00f;
        audioSource.volume = 1.00f;
        // Mute alarmSource
        alarmSource.volume = 0.00f;
        // Play the intro into the loop
        audioSource.PlayOneShot(audioIntro);
        audioSource.PlayScheduled(AudioSettings.dspTime + audioIntro.length);
    }

    void FixedUpdate()
    {
        // Detect distance between player and lava
        Vector2 playerpos = player.transform.position;
        Vector2 lavapos = lava.transform.position;
        if (playerpos.y < lavapos.y + MinPos)
        {
            PitchUp();
            AlarmOn();
        }
        else if (playerpos.y > lavapos.y + MaxPos)
        {
            PitchDown();
            AlarmOff();
        }
        if (playerpos.y < lavapos.y + 10)
        {
            ShutDown();
            AlarmOff();
            if (audioSource.volume <= 0)
                // Restart the game once the music dies
                SceneManager.LoadScene("Main-Prototype");
        }
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

    void ShutDown()
    {
        // Lower the volume
        if (audioSource.volume <= 0f) return;
        if (audioSource.volume > 0f)
        {
            audioSource.volume -= 0.005f;
        }
    }

    void AlarmOff()
    {
        // Lower the volume
        if (alarmSource.volume <= 0f) return;
        if (alarmSource.volume > 0f)
        {
            alarmSource.volume -= 0.05f;
        }
    }
    void AlarmOn()
    {
        // Raise the volume
        if (alarmSource.volume >= .5f) return;
        if (alarmSource.volume < .5f)
        {
            alarmSource.volume += 0.05f;
        }
    }
}
