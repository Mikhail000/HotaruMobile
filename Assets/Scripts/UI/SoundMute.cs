using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMute : MonoBehaviour
{
    public Sprite muteButton;
    public Sprite unmuteButton;

    private float playerMuse;//player shooting

    private float mainTheme;//main song

    private bool isMute = false;//initially all sounds are turned on

    //private void Start()
    //{
    //    playerMuse = GameObject.FindGameObjectWithTag("PlayerShipTag").GetComponent<AudioSource>().volume;
    //    mainTheme = GameObject.Find("Audio Source").GetComponent<AudioSource>().volume;
    //}

    public void PressMute()
    {
        if(isMute == false)//if sounds is turned on, turn if off
        {
            playerMuse = GameObject.FindGameObjectWithTag("PlayerShipTag").GetComponent<AudioSource>().volume = 0;
            mainTheme = GameObject.Find("Audio Source").GetComponent<AudioSource>().volume = 0;
            gameObject.GetComponent<Image>().sprite = muteButton;
            isMute = true;
        }
        else if(isMute == true)//if sounds is turned off, turn if on
        {
            playerMuse = GameObject.FindGameObjectWithTag("PlayerShipTag").GetComponent<AudioSource>().volume = 1;
            mainTheme = GameObject.Find("Audio Source").GetComponent<AudioSource>().volume = 1;
            gameObject.GetComponent<Image>().sprite = unmuteButton;
            isMute = false;
        }
        
    }
}
