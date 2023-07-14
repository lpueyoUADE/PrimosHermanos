using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desert_PlayAudio : MonoBehaviour
{
    public AudioSource audioScr;
    // Start is called before the first frame update
    void Start()
    {
        audioScr = GetComponent<AudioSource>();
    }

    public void PlayTheAudio(bool isLooping = true)
    {
        audioScr.Play();
        audioScr.loop = isLooping;
    }
}
