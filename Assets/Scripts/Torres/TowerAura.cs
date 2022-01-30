using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAura : MonoBehaviour
{
    public SphereCollider collider;

    public bool Dmg;
    public float boostDmg;
    public float speedBoost;
    
    public float range;

    void Start()
    {
        collider.radius = range;
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Torre")
        {
            TowerController Bullet = other.GetComponent<TowerController>();
            BulletController bullet = Bullet.GetComponent<BulletController>();
            if(Dmg)
            {
                if(Bullet.Poison)
                {
                    bullet.PoisonedDamage *= boostDmg;
                }
                else if (Bullet.UseLaser || Bullet.UsePlasma)
                {
                    Bullet.damageOverTime *= boostDmg;
                }
                else
                {
                    bullet.danio *= boostDmg;
                    bullet.danioMin *= boostDmg;
                }
            }
            else
            {
                Bullet.fireRate *= speedBoost;
            }
        }
    }
    

}
