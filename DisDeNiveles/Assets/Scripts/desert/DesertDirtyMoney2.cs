using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertDirtyMoney2 : MonoBehaviour
{
    public DesertRiseCars walterCar;
    public DesertRiseCars hankCar;

    public void StartExec()
    {
        walterCar.EnableRisingCars();
    }

    public void RiseHankCar()
    {
        hankCar.EnableRisingCars();
    }
}
