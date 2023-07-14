using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertDirtyMoney1 : Interactable
{
    public DesertBarrelInteract[] desertBarrels;
    public AudioClip activateSound;
    public AudioSource audioSrc;
    public DesertShovel dShovelScript;
    public UISimpleSubtitlesObject subScript;

    [Header("elevator stuff")]
    public GameObject newElevatorPosition;
    public GameObject elevatorRef;

    [Header("ui stuff")]
    public DesertBarrelsUI dbui;

    [Header("additional helpers")]
    public GameObject[] activateAdditionalStuff;

    public override void Interact()
    {
        if (!_alreadyInteracted)
        {
            base.Interact();
            elevatorRef.transform.position = newElevatorPosition.transform.position;
            elevatorRef.GetComponent<Elevator>().CloseDoors();

            audioSrc.loop = false;
            audioSrc.Stop();
            audioSrc.PlayOneShot(activateSound);

            dShovelScript.EnableShovel();

            _alreadyInteracted = true;
            subScript.StartExec();
            dbui.ShowBarrels();

            for (int i = 0; i < desertBarrels.Length - 1; i++)
            {
                desertBarrels[i].canBeInteracted = true;
                desertBarrels[i].EnableRingtone();
            }

            if (activateAdditionalStuff.Length != 0)
            {
                for (int i = 0; i < activateAdditionalStuff.Length; i++)
                    activateAdditionalStuff[i].SetActive(true);
            }
        }
    }
}
