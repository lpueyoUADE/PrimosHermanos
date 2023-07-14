using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEnableWalterWhite : Interactable
{
    public DesertWalterEnableAndLookAtPlayer walterWhite;
    public AudioSource stopThis;

    public override void Interact()
    {
        base.Interact();
        _alreadyInteracted = true;
        walterWhite.gameObject.SetActive(true);
        stopThis.Stop();
    }
}
