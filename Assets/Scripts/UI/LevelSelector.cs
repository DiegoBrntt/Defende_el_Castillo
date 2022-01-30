using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader Fader;

    public Button[] LevelButton;

    void Start() 
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        
        for (int i = 0; i < LevelButton.Length; i++)
        {
            if(i++ > levelReached)
            {
                LevelButton[i].interactable = false;
            }
        }
    } 
    
    public void Select(string LevelName)
    {
        Fader.FadeTo(LevelName);
    }
}
