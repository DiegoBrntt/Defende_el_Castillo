using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint RapidShootTower;
    public TurretBlueprint ExplosiveTower;
    public TurretBlueprint IceTower;
    public TurretBlueprint PoisonTower;
    public TurretBlueprint PlasmaTower;
    public TurretBlueprint AuraBoostTower;
    GameManager buildManager;

    void Start()
    {
        buildManager = GameManager.instance;
    }
    public void SelectRapidShootTower()
    {
        Debug.Log("Rapid Shoot Tower Selected.");
        buildManager.SelectTurretToBuild(RapidShootTower);
    }

    public void SelectExplosiveTower()
    {
        Debug.Log("Explosive Tower Selected.");
        buildManager.SelectTurretToBuild(ExplosiveTower);
    }
    public void SelectIceTower()
    {
        Debug.Log("Ice Tower Selected.");
        buildManager.SelectTurretToBuild(IceTower);
    }
    public void SelectPoisonTower()
    {
        Debug.Log("Poison Tower Selected.");
        buildManager.SelectTurretToBuild(PoisonTower);
    }
    public void SelectPlasmaTower()
    {
        Debug.Log("Plasma Tower Selected.");
        buildManager.SelectTurretToBuild(PlasmaTower);
    }
    public void SelectAuraBoostTower()
    {
        Debug.Log("Aura Boost Tower Selected.");
        buildManager.SelectTurretToBuild(AuraBoostTower);
    }
}
