using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Interactable Script")]
    public bool toggeable = false;
    public bool active = false;

    public bool _alreadyInteracted = false;
    public virtual void Interact()
    {
        if (isInteractable())
        {
            _alreadyInteracted = true;
            active = !active;
        }
    }

    public bool getAlreadyInteracted()
    {
        return _alreadyInteracted;
    }

    public bool isInteractable()
    {
        return (!_alreadyInteracted && active) || toggeable;
    }
}