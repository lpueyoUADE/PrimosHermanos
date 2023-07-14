using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertRiseCars : MonoBehaviour
{
    public Desert_PlayAudio additionalAudio;
    public GameObject cars;
    public float speed = 1;
    public float riseAmount = 8.82f;

    public bool rise = false;


    // Update is called once per frame
    void Update()
    {
        if (rise && cars.transform.position.y < riseAmount)
        {
            cars.transform.position = new Vector3(
                cars.transform.position.x,
                cars.transform.position.y + Time.deltaTime * speed,
                cars.transform.position.z
                );
        }
        else
            rise = false;
    }

    public void EnableRisingCars()
    {
        rise = true;
        if (additionalAudio != null)
        {
            additionalAudio.PlayTheAudio();
        }
    }
}
