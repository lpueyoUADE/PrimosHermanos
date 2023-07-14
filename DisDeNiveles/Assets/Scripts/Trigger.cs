using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent TriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter.Invoke();
    }

}
