using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoPrueba : MonoBehaviour
{
    [Header("VELOCIDAD")]
    public float startVel;
    public float Vel;
    [Header("VIDA")]
    public float startVida;
    private float Vida;
    
    [Header("WORTH")]
    public int gold;

    

    public Transform targetHit;
    public GameObject DieEffect;

    [Header("Unity Stuff")]
    public bool isPoisoned = false;

    public bool isDead = false;
    public Image healthBar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Vel = startVel;
        Vida = startVida;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(0, 0, Vel * Time.deltaTime));
       
    }

    public void TakeDamage(float danio)
    {
        
        Vida -= danio;
        healthBar.fillAmount = Vida / startVida;
        
        if(Vida <= 0 && !isDead)
        {
            Morir();
            Debug.Log("Murio");
        }
        
        
    }

    public void Poisoned (float PoisonedTime, float danio)
    {
        StartCoroutine(poisonDamage(PoisonedTime, danio));
    }

    IEnumerator poisonDamage (float PoisonedTime, float danio)
    {
        PoisonedTime -= Time.deltaTime;

        float contadorDeTiempo = 0;

        float contadorDeTiempoParaDanio = 0.5f;

        TakeDamage(danio);

        while (contadorDeTiempo <= PoisonedTime)
        {

            contadorDeTiempo += Time.deltaTime;

            contadorDeTiempoParaDanio += Time.deltaTime;

        if (contadorDeTiempoParaDanio >= 1)
        {

            TakeDamage(danio);

            contadorDeTiempoParaDanio = 0;

        }
        if(PoisonedTime <= 0)
        {
            StopAllCoroutines();
        }

        yield return null;

    }

}

    public void Slow(float slowSpeed)
    {
        Vel = startVel / slowSpeed;
    }

    void Morir()
    {
       isDead = true;


       
       GameObject death =(GameObject)Instantiate(DieEffect, transform.position, Quaternion.identity);
       
       SpawnerWaves.enemiesAlive--;
       GameManager.instance.enemiesKill++;
       GameManager.instance.Gold += gold;

       Destroy(gameObject);
    }

}
