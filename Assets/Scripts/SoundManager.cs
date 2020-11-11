using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource myAudio;

    public AudioClip sndCoin;
    public AudioClip sndClear;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayCoinSound()
    {
        myAudio.PlayOneShot(sndCoin);
    }

    public void PlayClearSound()
    {
        myAudio.PlayOneShot(sndClear);
    }
}
