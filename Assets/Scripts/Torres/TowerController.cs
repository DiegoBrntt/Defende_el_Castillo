using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private Transform target;
    private EnemigoPrueba targetEnemy;
    
    [Header("General")]
    public float Range;
    
    [Header("Use Bullet (default)")]
    public bool Poison = false;
    public float poisonDamage;
    public float poisonedTime; 
    public float fireRate;
    private float fireCountdown = 0f;
    public float danio;
    public float danioMin;
    public GameObject Bullet;

    [Header("Use Laser/Plasma")]
    public bool UseLaser = false;
    public bool UsePlasma = false;
    
    public float damageOverTime;
    public float  SlowSpeed;

    [Header("Aura stuff")]
    public float boostDmg;
    public float boostSpeed;
    public bool AuraDmg = false;
    public bool AuraSpeed = false;

    public LineRenderer lineRenderer;
    public ParticleSystem ImpactEffect;
    public Light HitEffect;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemigo";
    public float turnSpeed = 10f;
    public Transform towerHead;
    public Transform BulletSpawner;
    public GameObject RangeSprite;
    public bool animator = false;
    public Animator anim;



    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
        BulletController bulletCo = Bullet.GetComponent<BulletController>();
        danio = bulletCo.danio;
        danioMin = bulletCo.danioMin;
        poisonDamage = bulletCo.PoisonedDamage;
        poisonedTime = bulletCo.PoisonedTime;

    }

    
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject Enemy in enemies)
        {
            
            float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = Enemy;

            }

            if(nearestEnemy != null && shortestDistance <= Range)
            {
                targetEnemy = nearestEnemy.GetComponent<EnemigoPrueba>();
                target = targetEnemy.targetHit;
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
            if(UseLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    ImpactEffect.Stop();
                    HitEffect.enabled = false;
                    AudioManager.instance.Stop("Laser");
                }
            }
            towerHead.forward = Vector3.zero;
            return;
        }

        LockOnTarget();

        if(UseLaser)
        {
            Laser();
        }
        else
        {
           if(fireCountdown <= 0f)
           {
            Shoot();
            fireCountdown = 1f/fireRate;
           }

            fireCountdown -= Time.deltaTime;
        }

        
    }

    void LockOnTarget()
    {
        //Vector3 dir = target.position - transform.position;
        if(animator)
        {
            anim.SetBool("Atacando", true);
            towerHead.forward = target.position - towerHead.position;
        }
        
        towerHead.forward = target.position - towerHead.position;
    }

    void Laser()
    {
        
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(SlowSpeed);
        
        
        
        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            ImpactEffect.Play();
            HitEffect.enabled = true;

            
            
        }

        lineRenderer.SetPosition(0, BulletSpawner.position);
        lineRenderer.SetPosition(1, target.position);

        
        Vector3 dir = BulletSpawner.position - target.position;
        ImpactEffect.transform.position = target.position + dir.normalized * 0.1f;
        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(Bullet, BulletSpawner.position, BulletSpawner.rotation);
        BulletController bullet = BulletGO.GetComponent<BulletController>();

        

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }


    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
