using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertJesseHint : Interactable
{
    [Header("subtitle")]
    public UISimpleSubtitlesObject subScript;

    public override void Interact()
    {
        if (!_alreadyInteracted)
        {
            base.Interact();
            _alreadyInteracted = true;
            subScript.StartExec();
        }
    }
}
