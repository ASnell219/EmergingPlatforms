using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySong : MonoBehaviour
{
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        _audioSource.Play();
    }

    public void PauseAudio()
    {
        _audioSource.Pause();
    }

    public void StopAudio()
    {
        _audioSource.Stop();
    }
}
