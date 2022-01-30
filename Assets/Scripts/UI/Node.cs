using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 positionOffset;
   
    [HideInInspector]
    public GameObject Turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool Level1 = false;
    public bool Level2 = false;
    public bool LevelMax = false;
    private Renderer rend;
    private Color StartColor;
    GameManager buildManager;

    void Start() 
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildManager = GameManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown() 
    {
        if(EventSystem.current.IsPointerOverGameObject())return;
        

        if(Turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        
        if(!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
       if(buildManager.Gold < blueprint.Cost)
        {
            Debug.Log("Not enough gold.");
            return;
        }

        buildManager.Gold -= blueprint.Cost;
        
        GameObject turret = (GameObject)Instantiate(blueprint.Turret, GetBuildPosition(), Quaternion.identity);
        Turret = turret;

        turretBlueprint = blueprint;

        GameObject effect =(GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosition(), transform.rotation);
        Destroy(effect, 2f);
        
        Level1 = true;

        Debug.Log("Turret Build!");
    }
    public void UpgradeTurret()
    {

        if(Level1)
        {
            if(buildManager.Gold < turretBlueprint.UpgradeCost[0])
            {
                Debug.Log("Not enough gold to upgrade.");
                return;
            }

            buildManager.Gold -= turretBlueprint.UpgradeCost[0];

            Destroy(Turret);
        
            GameObject turret = (GameObject)Instantiate(turretBlueprint.UpgradedTurret[0], GetBuildPosition(), Quaternion.identity);
            Turret = turret;

            GameObject effect =(GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosition(), transform.rotation);
            Destroy(effect, 2f);

            Level1 = false;
            Level2 = true;
            return;
        }

        if(Level2)
        {
            if(buildManager.Gold < turretBlueprint.UpgradeCost[1])
            {
                Debug.Log("Not enough gold to upgrade.");
                return;
            }

            buildManager.Gold -= turretBlueprint.UpgradeCost[1];

            Destroy(Turret);
        
            GameObject turret = (GameObject)Instantiate(turretBlueprint.UpgradedTurret[1], GetBuildPosition(), Quaternion.identity);
            Turret = turret;

            GameObject effect =(GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosition(), transform.rotation);
            Destroy(effect, 2f);

            Level2 = false;
            LevelMax = true;
        }


        Debug.Log("Turret Upgraded!");
    }
    public void SellTurret()
    {
        buildManager.Gold += turretBlueprint.GetSellAmount();
        Destroy(Turret);
        turretBlueprint = null;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild)return;
        if(buildManager.HasGold)
        {
            rend.material.color = HoverColor;
        }
        else 
        {
            rend.material.color = Color.red;
        }
        
    }

    private void OnMouseExit() 
    {
        rend.material.color = StartColor;
    }
}
