using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Enemigo")
        {
            AudioManager.instance.Play("PerderVida");
            gameManager.Lives--;
            SpawnerWaves.enemiesAlive--;
            Destroy(other.gameObject);
        }
    }
}
