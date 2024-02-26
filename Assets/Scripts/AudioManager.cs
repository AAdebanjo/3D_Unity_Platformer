using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;
    public AudioClip[] musicTracks;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = musicTracks[0];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameplayMusic() 
    {
        audioSource.clip = musicTracks[1];
        audioSource.Play();
    }

    public void PlayMenuMusic() 
    {
        audioSource.clip = musicTracks[0];
        audioSource.Play();
    }
}
