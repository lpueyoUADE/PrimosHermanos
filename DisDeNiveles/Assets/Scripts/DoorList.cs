using System;
using UnityEngine;

public abstract class DoorList : MonoBehaviour
{
    public Action<int> OpenDoorEvent;

    private void Start()
    {
        OpenDoorEvent += OpenDoor;
    }

    public abstract void OpenDoor(int ID);
}
