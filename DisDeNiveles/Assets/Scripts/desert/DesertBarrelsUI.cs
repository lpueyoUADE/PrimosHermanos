using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBarrelsUI : MonoBehaviour
{
    public GameObject[] barrels;

    public void ShowBarrels()
    {
        for (int i = 0; i < barrels.Length; i++)
            barrels[i].SetActive(true);
    }

    public void RemoveOneBarrel(int whichOne)
    {
        barrels[whichOne].SetActive(false);
    }


}
