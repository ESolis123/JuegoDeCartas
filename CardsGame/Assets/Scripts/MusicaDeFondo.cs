using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaDeFondo : MonoBehaviour
{
    public AudioClip[]  clips;
    AudioSource fuenteAudio;

    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        PlayClip(clips[Random.Range(0, clips.Length)]);
    }

    public void PlayClip(AudioClip clip)
    {
        if(!fuenteAudio.isPlaying)
        {
            fuenteAudio.clip = clip;
            fuenteAudio.loop = true;
            fuenteAudio.Play();
        }
    }
}
