using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    //Build Turret.
    public GameObject Turret;
    public int Cost;
    //Upgrade Turret.
    public GameObject[] UpgradedTurret;
    public int[] UpgradeCost;

    public int GetSellAmount()
    {
        return Cost / 3;
    }
}
