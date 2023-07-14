using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBarrelsCheat : MonoBehaviour
{
    public GameObject[] barrels;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            for (int i = 0; i < barrels.Length; i++)
            {
                barrels[i].SetActive(true);
            }
    }
}
