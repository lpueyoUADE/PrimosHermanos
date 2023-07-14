using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertShovel : MonoBehaviour
{
    public GameObject shovel;
    public AudioSource audioScr;

    public float rotationTime = 3;
    public float rotationCurrent = 0;

    public void EnableShovel()
    {
        shovel.SetActive(true);
    }

    public void RotateShovel()
    {
        rotationCurrent = rotationTime;
        audioScr.Play();
    }

    private void Update()
    {
        if (rotationCurrent > 0)
        {
            rotationCurrent -= Time.deltaTime;
            shovel.transform.RotateAround(shovel.transform.position, Vector3.up, Time.deltaTime + 5);
        }
    }
}
