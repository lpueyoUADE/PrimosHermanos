using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrokenAmbulance : MonoBehaviour
{
    private bool hasDoor = false;
    private bool hasWheel = false;
    private bool hasEngine = false;
    [SerializeField] UnityEvent RepairDoor;
    [SerializeField] UnityEvent RepairWheel;
    [SerializeField] UnityEvent RepairEngine;
    [SerializeField] UnityEvent NewAmbulance;

    // Update is called once per frame
    void Update()
    {
        if (hasDoor && hasEngine && hasWheel)
        {
            NewAmbulance.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if(other.GetComponent<AmbulanceParts>().Door == true && hasDoor == false)
            {
                RepairDoor.Invoke();
                hasDoor = true;
            }

            if(other.GetComponent<AmbulanceParts>().Engine == true && hasEngine == false)
            {
                RepairEngine.Invoke();
                hasEngine = true;
            }

            if(other.GetComponent<AmbulanceParts>().Wheel == true && hasWheel == false)
            {
                RepairWheel.Invoke();
                hasWheel = true;
            }
        }
    }
}
