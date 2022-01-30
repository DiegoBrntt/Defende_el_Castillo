using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform target;
    public GameObject EfectoImpacto;
    public float Vel;

    [Header("Normal explosion")]
    public float RangoExplosion;
    public float danio;
    public float danioMin; 
    [Header("Poison")]
    public bool poisonShoot;
    public float RangoMax;
    public float PoisonedTime = 20f;
    public float PoisonedDamage = 10f;

    
    public void Seek(Transform _target)
    {
        target = _target;
    } 
    void Update()
    {
        //transform.Translate(0, 0, Vel * Time.deltaTime);
        //Destroy(gameObject, 2f);

        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Vel * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }



        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject efect = (GameObject)Instantiate(EfectoImpacto, transform.position, transform.rotation);

        if(RangoExplosion > 0f)
        {
            if(poisonShoot)
            {
                Poison();
            }
            else
            {
                Explosion();
            }
        }
        else 
        {
            Damage(target.gameObject);
        }

        
        Destroy(gameObject);
    }

    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, RangoExplosion);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemigo")
            {
                DamageExplode(collider.gameObject);
            }
        }
    }

    public void Poison()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, RangoMax);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemigo")
            {
                EnemigoPrueba E = collider.GetComponent<EnemigoPrueba>();

                if (E != null)
                {
                    E.Poisoned(PoisonedTime, PoisonedDamage);
                }
            }
        }
    }
    void DamageExplode(GameObject enemy)
    {
       EnemigoPrueba E = enemy.GetComponent<EnemigoPrueba>();
       
       if(E != null)
       {
        E.TakeDamage(Mathf.Lerp(danio, danioMin, Vector3.Distance(target.position, E.transform.position)/RangoExplosion));
       }
    }

    void Damage(GameObject enemy)
    {
       EnemigoPrueba E = enemy.GetComponent<EnemigoPrueba>();
       
       if(E != null)
       {
        E.TakeDamage(danio);
       }
    }
    void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, RangoExplosion);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangoMax);
    }
}
