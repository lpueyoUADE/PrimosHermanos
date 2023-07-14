using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertLidOpen : Interactable
{
    public DesertAudioClips audioClips;

    public AudioSource audioSrc;
    public GameObject lid;
    public GameObject[] additionalActivations;

    public Vector3 movementOffset;

    private void Start()
    {
        lid.SetActive(true);
    }

    public override void Interact()
    {
        if (!_alreadyInteracted)
        {
            _alreadyInteracted = true;

            if (additionalActivations.Length != 0)
                for (int i = 0; i < additionalActivations.Length; i++)
                    additionalActivations[i].SetActive(true);

            base.Interact();
            audioSrc.PlayOneShot(audioClips.GetNextAudioClip());

            lid.gameObject.transform.position = new Vector3(
                lid.gameObject.transform.position.x + movementOffset.x, 
                lid.gameObject.transform.position.y + movementOffset.y, 
                lid.gameObject.transform.position.z + movementOffset.z);
        }
    }
}
