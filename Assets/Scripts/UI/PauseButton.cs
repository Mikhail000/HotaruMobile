using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite unpauseSprite;

    private Sprite pauseBut;

    bool chechState;

    public void ChangeState()
    {
        if (chechState = GameObject.FindObjectOfType<ContinueGame>().gameIsRun)
        {
            Pause();
        }
        else if (chechState = GameObject.FindObjectOfType<ContinueGame>().gameIsRun == false)
        {
            Resume();
        }
    }

    void Pause()
    {
        GameObject.FindObjectOfType<ContinueGame>().gameIsRun = false;
        Time.timeScale = 0f;
        GameObject handler = GameObject.Find("LoadingHandler");
        handler.GetComponent<SceneHandler>().gameIsPause = true;
        handler.GetComponent<SceneHandler>().pauseMenu.SetActive(true);
        pauseBut = GameObject.Find("PauseBut").GetComponent<Image>().sprite = pauseSprite;
    }

    public void Resume()
    {
        GameObject.FindObjectOfType<ContinueGame>().gameIsRun = true;
        Time.timeScale = 1f;
        GameObject handler = GameObject.Find("LoadingHandler");
        handler.GetComponent<SceneHandler>().gameIsPause = false;
        handler.GetComponent<SceneHandler>().pauseMenu.SetActive(false);
        pauseBut = GameObject.Find("PauseBut").GetComponent<Image>().sprite = unpauseSprite;
    }
}
