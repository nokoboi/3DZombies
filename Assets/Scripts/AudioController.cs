using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip; // Asigna tu AudioClip aquí desde el inspector
    private AudioSource audioSource;

    void Start()
    {
        // Agrega un componente AudioSource al GameObject actual si no lo tiene
        audioSource = gameObject.AddComponent<AudioSource>();
        // Asigna el AudioClip que deseas reproducir
        audioSource.clip = audioClip;
    }

    public void PlayAudio()
    {
        if (audioSource != null && audioClip != null)
        {
            // Reproduce el audio
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource o AudioClip no asignado.");
        }
    }
}
