using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public Text Kill;
    public Text Waves;
    public Button pausa;
    public Button TimeCont;
    public string menuScene = "Menu";

    public string nextLevel = "Dificil";
    public int levelToUnlock;

    public SceneFader sceneFader;

    void OnEnable() 
    {
        Waves.text = GameManager.Waves.ToString();
        Kill.text = GameManager.instance.enemiesKill.ToString();
        Time.timeScale = 0;
        pausa.interactable = false;
        TimeCont.interactable = false;
        AudioManager.instance.Stop("Theme");
        AudioManager.instance.Play("Ganar");
    }


    public void Menu()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(menuScene);
        AudioManager.instance.Stop("Ganar");
        AudioManager.instance.Play("Theme");
    }

    public void SiguenteNivel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
        AudioManager.instance.Stop("Ganar");
        AudioManager.instance.Play("Theme");
    }
}
