using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    [Header("Sell-Upgrade")]
    public Text Danio;
    public Text DanioMin;
    public Text Range;
    public Text UpgradeCost;
    public Button upgradeBotton;
    public Text sellAmount;
    public GameObject UI;
    public bool spriteRange = false;



    
    public void SetTarget(Node _target)
    {
       target = _target;
       TowerController turret = target.Turret.GetComponent<TowerController>();
       if(target.LevelMax)
       {
           UpgradeCost.text = "Done.";
           upgradeBotton.interactable = false;
           if(turret.Poison)
           {
                Danio.text = "Daño: " + turret.poisonDamage;
                DanioMin.text = "Tiempo: " + turret.danioMin;
                Range.text = "Rango: " + turret.Range;
           }
           else if(turret.UseLaser || turret.UsePlasma)
            {
                Danio.text = "Daño: " + turret.damageOverTime;
                DanioMin.text = "Reduccion: " + turret.SlowSpeed;
                Range.text = "Rango: " + turret.Range;
            }
           else
           {
                Danio.text = "Daño: " + turret.danio;
                DanioMin.text = "Daño: " + turret.danioMin;
                Range.text = "Rango: " + turret.Range;
           }
       }
       else
       {
            if(target.Level1)
                {
                    UpgradeCost.text = "$" + target.turretBlueprint.UpgradeCost[0];
                    upgradeBotton.interactable = true;
                    if(turret.Poison)
                    {
                        Danio.text = "Daño: " + turret.poisonDamage;
                        DanioMin.text = "Tiempo: " + turret.danioMin;
                        Range.text = "Rango: " + turret.Range;
                    }
                    else if(turret.UseLaser || turret.UsePlasma)
                    {
                        Danio.text = "Daño: " + turret.damageOverTime;
                        DanioMin.text = "Reduccion: " + turret.SlowSpeed;
                        Range.text = "Rango: " + turret.Range;
                    }
                    else
                    {
                        Danio.text = "Daño: " + turret.danio;
                        DanioMin.text = "Daño: " + turret.danioMin;
                        Range.text = "Rango: " + turret.Range;
                    }
                }
            else if(target.Level2)
                {
                    UpgradeCost.text = "$" + target.turretBlueprint.UpgradeCost[1];
                    upgradeBotton.interactable = true;
                    if(turret.Poison)
                    {
                        Danio.text = "Daño: " + turret.poisonDamage;
                        DanioMin.text = "Duracion: " + turret.danioMin;
                        Range.text = "Rango: " + turret.Range;
                    }
                    else if(turret.UseLaser || turret.UsePlasma)
                    {
                        Danio.text = "Daño: " + turret.damageOverTime;
                        DanioMin.text = "Reduccion: " + turret.SlowSpeed;
                        Range.text = "Rango: " + turret.Range;
                    }
                    else
                   {
                        Danio.text = "Daño: " + turret.danio;
                        DanioMin.text = "Daño: " + turret.danioMin;
                        Range.text = "Rango: " + turret.Range;
                   }
                }
           
       }

       sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
       
       UI.SetActive(true);
       turret.RangeSprite.SetActive(true);

    }

    public void Hide()
    {
        TowerController turret = target.Turret.GetComponent<TowerController>();
        UI.SetActive(false);
        turret.RangeSprite.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        GameManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        GameManager.instance.DeselectNode();
    }
}
