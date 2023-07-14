using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlayer : MonoBehaviour
{
    public float timeOn = 5;

    // Update is called once per frame
    void FixedUpdate()
    {
        timeOn -= Time.deltaTime;

        if (timeOn <= 0)
            this.gameObject.SetActive(false);
    }
}
