using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad = "Dificultades";
    public string configuracion = "Config";
    public string Info = "Info";

    public SceneFader sceneFader;
    
    public void Play()
    {
        sceneFader.FadeTo(LevelToLoad);
    }

    public void Config()
    {
        sceneFader.FadeTo(configuracion);
    }

    public void Informacion()
    {
        sceneFader.FadeTo(Info);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
