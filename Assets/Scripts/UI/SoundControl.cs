using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public GameObject SoundButton;
    public Sprite audioOffSprite;
    public Sprite audioOnSprite;
    
    public void Start()
    {
        if(AudioListener.pause == true)
        {
            SoundButton.GetComponent<Image>().sprite = audioOffSprite;
        }     
        else 
        {
            SoundButton.GetComponent<Image>().sprite = audioOnSprite;
        }
    }

    public void SoundController()
    {
        if(AudioListener.pause == true)
        {
            AudioListener.pause = false;
            SoundButton.GetComponent<Image>().sprite = audioOnSprite;
        }     
        else 
        {
            AudioListener.pause = true;
            SoundButton.GetComponent<Image>().sprite = audioOffSprite;
        }
    }
}
