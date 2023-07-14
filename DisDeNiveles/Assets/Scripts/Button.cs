using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    [Header("Button Script")]
    public AudioClip onSFX;
    public AudioClip offSFX;

    public Material _onMaterial;
    public Material _offMaterial;
    protected AudioSource audioSRC;

    private void Start()
    {
        audioSRC = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();

        if (_alreadyInteracted)
        {
            GetComponent<MeshRenderer>().material = _onMaterial;
            audioSRC.PlayOneShot(onSFX);
        }
        else
        {
            GetComponent<MeshRenderer>().material = _offMaterial;
            audioSRC.PlayOneShot(offSFX);
        }
    }
}
