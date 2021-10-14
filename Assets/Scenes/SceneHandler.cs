using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneHandler : SceneLoader<SceneHandler>
{
    int spawnerIsReady;

    GameObject scoreBody;
    int absHP;
    public GameObject playerPref;
    public GameObject dropItemsPref;

    [Header("Корабли-боссы")]
    public GameObject firstBoss;
    public GameObject secondBoss;
    public GameObject thirdBoss;
    public GameObject fourthBoss;
    Vector2 bossSpawnPosition = new Vector2(0, 5f);

    [Header("Спаунеры волн")]
    public GameObject firstWaveSpawner;
    public GameObject secondWaveSpawner;
    public GameObject thirdWaveSpawner;
    public GameObject fourthWaveSpawner;

    [Header("Спаунер метеоров")]
    public GameObject cometSpawner;

    [Header("UI")]
    public GameObject finalMenuPref;
    GameObject finalMenu;
    public GameObject pauseMenuPref;
    [HideInInspector]
    public GameObject pauseMenu;
    public GameObject playerInterfacePref;
    GameObject playerInterface;
    Text liveText;

    [HideInInspector]
    public bool gameIsPause = false;

    private void Awake()
    {
        playerInterface = Instantiate(playerInterfacePref);

        finalMenu = Instantiate(finalMenuPref);
        finalMenu.SetActive(false);

        pauseMenu = Instantiate(pauseMenuPref);
        pauseMenu.SetActive(false);

        Instantiate(dropItemsPref);

        liveText = GameObject.FindGameObjectWithTag("LivesTextTag").GetComponent<Text>();
        //liveText.text = absHP.ToString();

    }

    void Start()
    {
        Instantiate(cometSpawner);
        Instantiate(playerPref);
        spawnerIsReady = 1;
        scoreBody = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    void Update()
    {
        SpawnHandler();
    }

    void SpawnHandler()
    {
        if (GameObject.FindGameObjectWithTag("PlayerShipTag") != null)
        {
            //First wave instantiate(1)
            if (scoreBody.GetComponent<GameScore>().Score == 0 && spawnerIsReady == 1)
            {
                Instantiate(firstWaveSpawner);
                spawnerIsReady = 2;
            }
            //First boss instantiate(2)
            else if (scoreBody.GetComponent<GameScore>().Score >= 2500 && spawnerIsReady == 2)
            {
                Destroy(GameObject.Find("FirstWaveSpawner(Clone)"));
                Instantiate(firstBoss, bossSpawnPosition, Quaternion.identity);
                spawnerIsReady = 3;
            }
            //Second wave instantiate(3)
            else if (scoreBody.GetComponent<GameScore>().Score >= 3500 && spawnerIsReady == 3)
            {
                Destroy(GameObject.Find("Boss_1(Clone)"));
                Instantiate(secondWaveSpawner);
                spawnerIsReady = 4;
            }
            //Second boss instantiate(4)
            else if (scoreBody.GetComponent<GameScore>().Score >= 6000 && spawnerIsReady == 4)
            {
                Destroy(GameObject.Find("SecondWaveSpawner(Clone)"));
                Instantiate(secondBoss, bossSpawnPosition, Quaternion.identity);
                spawnerIsReady = 5;
            }
            //Third wave instantiate(5)
            else if (scoreBody.GetComponent<GameScore>().Score >= 7000 && spawnerIsReady == 5)
            {
                Destroy(GameObject.Find("Boss_2(Clone)"));
                Instantiate(thirdWaveSpawner);
                spawnerIsReady = 6;
            }
            //Third boss instantiate(6)
            else if (scoreBody.GetComponent<GameScore>().Score >= 10000 && spawnerIsReady == 6)
            {
                Destroy(GameObject.Find("ThirdWaveSpawner(Clone)"));
                Instantiate(thirdBoss, bossSpawnPosition, Quaternion.identity);
                spawnerIsReady = 7;
            }
            //Fourth wave instantiate(7)
            else if (scoreBody.GetComponent<GameScore>().Score >= 11000 && spawnerIsReady == 7)
            {
                Destroy(GameObject.Find("Boss_3(Clone)"));
                Instantiate(fourthWaveSpawner);
                spawnerIsReady = 8;
            }
            //Fourth boss instantiate(8)
            else if (scoreBody.GetComponent<GameScore>().Score >= 14500 && spawnerIsReady == 8)
            {
                Destroy(GameObject.Find("FourthWaveSpawner(Clone)"));
                Instantiate(fourthBoss, bossSpawnPosition, Quaternion.identity);
                spawnerIsReady = 9;
            }
        }
        else
            finalMenu.SetActive(true);
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

}