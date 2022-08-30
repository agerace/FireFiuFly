using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;

    private void Start()
    {
        audioSource.clip = music;
        audioSource.Play();
        audioSource.loop = true;
    }
    public void playSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
