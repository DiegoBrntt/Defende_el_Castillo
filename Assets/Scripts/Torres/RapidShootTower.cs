using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidShootTower : MonoBehaviour
{
    private Transform target;
     
    [Header("Attributes")]
    public float Range = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Auras")]
    public float BoostDamage;
    public float BoostVel;
    public bool SpeedBoost = false;
    public bool DmgBoost = false;
    
    [Header("Unity Setup Fields")]
    public string enemyLayer = "Enemigo";
    public float turnSpeed = 10f;
    public Transform towerHead;
    public Animator animator;

    public GameObject Bala;
    public Transform Disparador1;
    public Transform Disparador2;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyLayer);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemigo = null;
        foreach (GameObject Enemigo in enemies)
        {
            float distanceToEnemigo = Vector3.Distance(transform.position, Enemigo.transform.position);
            
            if(distanceToEnemigo < shortestDistance)
            {
                shortestDistance = distanceToEnemigo;
                nearestEnemigo = Enemigo;
            }

            if(nearestEnemigo != null && shortestDistance <= Range)
            {
                target = nearestEnemigo.transform;
            }
            else 
            {
                target = null;
            }
        }
    }


    void Update()
    {
        if(target == null)
        {
            towerHead.forward = Vector3.zero;
            return;
        }

        Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(towerHead.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //towerHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        towerHead.forward = target.transform.position - towerHead.transform.position;

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/fireRate;
            
        }

        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        GameObject balaGO1 = (GameObject)Instantiate(Bala, Disparador1.position, Disparador1.rotation);
        GameObject balaGO2 = (GameObject)Instantiate(Bala, Disparador2.position, Disparador2.rotation);
        BulletController bala1 = balaGO1.GetComponent<BulletController>();
        BulletController bala2 = balaGO2.GetComponent<BulletController>();

        if(DmgBoost)
        {
            bala1.danio *= BoostDamage;
            bala2.danio *= BoostDamage;
        }

        if(SpeedBoost)
        {
            fireRate *= BoostVel;
        }

        if(bala1 != null)
        {
            bala1.Seek(target);
        }

        if(bala2 != null)
        {
            bala2.Seek(target);
        }
        
    }

    void OnTriggerEnter(Collider other) 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Range);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "auraSpd")
            {
                TowerController turret = collider.GetComponent<TowerController>();
                RapidShootTower turretR = collider.GetComponent<RapidShootTower>();
                turret.AuraSpeed = true;
                turretR.SpeedBoost = true;
            }
            if(collider.tag == "auraDmg")
            {
                TowerController turret = collider.GetComponent<TowerController>();
                RapidShootTower turretR = collider.GetComponent<RapidShootTower>();
                turret.AuraDmg = true;
                turretR.DmgBoost = true;
            }
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
