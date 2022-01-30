using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    public Button PauseButton;
    public Button ContinueButton;

    public Button TimeBut;

    public Text x3;

    public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);

        if(UI.activeSelf)
        {
            Time.timeScale = 0f;
            PauseButton.interactable = false;
            TimeBut.interactable = false;
            ContinueButton.interactable = true;
        }
        else
        {
            Time.timeScale = 1f;
            PauseButton.interactable = true;
            TimeBut.interactable = true;
            ContinueButton.interactable = false;
        }
    }

    public void Reset()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
		sceneFader.FadeTo(menuSceneName);
    }

    public void TimeControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 3;
            x3.text = "Tiempo x1";
        }     
        else 
        {
            Time.timeScale = 1;
            x3.text = "Tiempo x3";
        }
    }


}
