using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Stats")]
    public int Gold;
    public int startGold;
    public Text gold;
    public int Lives;
    public static int Waves;
    public int enemiesKill = 0;
    
    public int startLives = 20;
    [Header("Perder-Ganar")]

    public static bool GameEnd;
    public GameObject GameOverUI;
    public GameObject CompleteLevelUI;
    public Text lives;
    [Header("Turrets")]
    public GameObject RapidTurret;
    public GameObject MissileTurret;
    public GameObject PoisonTower;
    public GameObject IceTower;
    public GameObject PlasmaTower;
    public GameObject AuraBoostTower;

    [Header("Effects")]
    public GameObject BuildEffect;
    
    [Header("Build Manager")]
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
    

    void Awake() 
    {
        if(instance != null)
        {
            Debug.LogError("Mas de un GameManager en escena");
            return;
        }
        instance = this;
    }
    void Start()
    {
        GameEnd = false;
        Gold = startGold;
        Lives = startLives;
        Waves = 0;
    }
    void Update()
    {
        //Stats
        gold.text = "Gold:" + Gold;
        lives.text = "Lives:" + Lives;

        //Perder
        if(GameEnd)
        {
            return;
        }

        if(Lives <= 0)
        {
            Perder();
        }
    }
    
    //Build Manager
    public bool CanBuild {get {return turretToBuild != null;} }
    public bool HasGold {get {return Gold >= turretToBuild.Cost;} }
    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint Turret)
   {
        turretToBuild = Turret;
        DeselectNode();
   }
   public TurretBlueprint GetTurretToBuild()
   {
       return turretToBuild;
   }

   //Ganar, Perder, Reset.

    public void Ganar()
    {
        GameEnd = true;
        CompleteLevelUI.SetActive(true);
    }
    void Perder ()
    {
        GameEnd = true;
        GameOverUI.SetActive(true);
    }
    void Reset()
    {
       Lives = startLives;
       Gold = startGold;
       Waves = 0;
       GameEnd = false;
    }
}
