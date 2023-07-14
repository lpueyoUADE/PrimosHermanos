using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : Button
{
    public Button ElevatorButton;

    public override void Interact()
    {
        base.Interact();

        if (_alreadyInteracted)
        {
            GetComponent<MeshRenderer>().material = _onMaterial;
            audioSRC.PlayOneShot(onSFX);
            ElevatorButton.active = true;
        }
        else
        {
            GetComponent<MeshRenderer>().material = _offMaterial;
            audioSRC.PlayOneShot(offSFX);
        }
    }
}
