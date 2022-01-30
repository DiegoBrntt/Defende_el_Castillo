using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerWaves : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    public GameObject Enemigo;
    public Transform SpawnPoint;

    public GameManager gameManager;

    private float timeNextWave = 20f;
    private float Countdown = 20f;

    public Text TimeNextWave;

    private int WaveIndex = 0;

    void Start() 
    {
        enemiesAlive = 0;
        WaveIndex = 0;    
    }

    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if(WaveIndex == waves.Length)
        {
           gameManager.Ganar();
           this.enabled = false;
        }
        
        if(Countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            Countdown = timeNextWave;
            return;
        }

        Countdown -= Time.deltaTime;

        Countdown = Mathf.Clamp(Countdown, 0f, Mathf.Infinity);

        TimeNextWave.text = string.Format("Wave: {0:00.00}", Countdown);
    }

    IEnumerator SpawnWave()
    {
        GameManager.Waves++;
        Wave wave = waves[WaveIndex];

        enemiesAlive = wave.Count;
        
        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }        
        WaveIndex++;

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
