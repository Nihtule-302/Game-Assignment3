using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioSource movementSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip beingHit;
    public AudioClip coin;
    public AudioClip moving;

    public bool playerIsMoving = false;

    void Start()
    {
        movementSource.clip = moving;
        movementSource.Play();
    }

    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.clip = clip;
        SFXSource.Play();
    }
}
