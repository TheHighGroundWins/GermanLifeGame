using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControls : MonoBehaviour
{
    //reference to the player's audio source
    [SerializeField] private AudioSource audioSource;
    public bool playMusic = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playMusic)
            audioSource.Pause();
        else
            audioSource.Play();
    }
}
