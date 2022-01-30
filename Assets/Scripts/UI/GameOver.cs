using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text waves;
    public Text Kills;
    public Button pausa;
    public Button TimeCont;

    public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;


    void OnEnable() 
    {
        waves.text = GameManager.Waves.ToString();
        Kills.text = GameManager.instance.enemiesKill.ToString();
        Time.timeScale = 0;
        pausa.interactable = false;
        TimeCont.interactable = false;
        AudioManager.instance.Stop("Theme");
        AudioManager.instance.Play("Perder");
    }

	public void Retry ()
	{
        Time.timeScale = 1;
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        AudioManager.instance.Stop("Perder");
        AudioManager.instance.Play("Theme");
    }

	public void Menu ()
	{
        Time.timeScale = 1;
		sceneFader.FadeTo(menuSceneName);
        AudioManager.instance.Stop("Perder");
        AudioManager.instance.Play("Theme");
	}

}
