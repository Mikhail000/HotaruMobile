using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    public float maxSpawnRateinSeconds = 2f;
	
	void Start ()
    {
        Invoke("MeteorSpawn", maxSpawnRateinSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 5f);
    }
	
	
	void FixedUpdate ()
    {
      
	}

    void MeteorSpawn()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        GameObject Meteor = (GameObject)Instantiate(meteor);
        Meteor.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextMeteorSpawn();
    }
    void ScheduleNextMeteorSpawn()
    {
        float spawnInSecond;
        if (maxSpawnRateinSeconds > 1f)
        {
            spawnInSecond = Random.Range(1f, maxSpawnRateinSeconds);
        }
        else
            spawnInSecond = 1f;
        Invoke("MeteorSpawn", spawnInSecond);
    }  
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateinSeconds > 1f)
            maxSpawnRateinSeconds--;

        if (maxSpawnRateinSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}

