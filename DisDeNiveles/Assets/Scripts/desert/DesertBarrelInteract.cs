using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBarrelInteract : Interactable
{
    [Header("DesertDirtyMoney Script")]
    public bool canBeInteracted = false;

    public AudioSource audioSrc;
    public AudioSource audioSrcRingtone;
    public DesertShovel dShovelScript;
    public MeshRenderer thisRenderer;
    public BoxCollider bCollider;
    public GameObject barrel;

    public override void Interact()
    {
        if (!_alreadyInteracted && canBeInteracted)
        {
            base.Interact();
            audioSrc.Play();

            dShovelScript.RotateShovel();

            _alreadyInteracted = true;
            thisRenderer.gameObject.SetActive(false);
            bCollider.gameObject.SetActive(false);
            barrel.SetActive(true);
        }
    }

    public void EnableRingtone()
    {
        audioSrcRingtone.Play();
    }
}
