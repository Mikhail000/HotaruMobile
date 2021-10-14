using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueGame : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite unpauseSprite;

    [HideInInspector]
    public bool gameIsRun = true;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = unpauseSprite;
    }

    public void ChangeState()
    {
        if (gameIsRun)
        {
            Pause();
        }
        else if(gameIsRun == false)
        {
            Resume();
        }
    }

    void Pause()
    {
        gameIsRun = false;
        Time.timeScale = 0f;
        GameObject handler = GameObject.Find("LoadingHandler");
        handler.GetComponent<SceneHandler>().gameIsPause = true;
        handler.GetComponent<SceneHandler>().pauseMenu.SetActive(true);
        gameObject.GetComponent<Image>().sprite = pauseSprite;
    }

    public void Resume()
    {
        gameIsRun = true;
        Time.timeScale = 1f;
        GameObject handler = GameObject.Find("LoadingHandler");
        handler.GetComponent<SceneHandler>().gameIsPause = false;
        handler.GetComponent<SceneHandler>().pauseMenu.SetActive(false);
        gameObject.GetComponent<Image>().sprite = unpauseSprite;
    }
}
