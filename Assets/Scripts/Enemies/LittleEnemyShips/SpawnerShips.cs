using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerShips : MonoBehaviour {

    public GameObject EnemyShip;
    float timeToStartSpawn = 0.5f;
    float maxSpawnRateInSeconds = 5f;

    //initialization
    void Start()
    {
        Invoke("SpawnShip", timeToStartSpawn);
        //increase spawn rate every 15 seconds
        InvokeRepeating("IncreaseSpawnRate", 1f, 15f);
    }

    //spawn enemy
    void SpawnShip()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        GameObject enShip = (GameObject)Instantiate(EnemyShip);
        enShip.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnShipSpawn();
    }
    void ScheduleNextEnShipSpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;
        Invoke("SpawnShip", spawnInSeconds);
    }
    //increase the difficulty of the game
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");

    }
}
