using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceParts : MonoBehaviour
{
    public Elevator elevScript;

    public bool Door = false;
    public bool Engine = false;
    public bool Wheel = false;
    [SerializeField] AudioSource success;

    private void Start()
    {
        elevScript.OpenDoors();
    }

    public void DoorCollected()
    {
        Door = true;
        success.Play();
    }

    public void EngineCollected()
    {
        Engine = true;
        success.Play();
    }

    public void WheelCollected()
    {
        Wheel = true;
        success.Play();
    }
}
