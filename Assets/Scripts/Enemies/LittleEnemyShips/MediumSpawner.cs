using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSpawner : MonoBehaviour {

    public GameObject ship;
    Vector2 spawnPoint;

    void Start()
    {
        InvokeRepeating("SpawnShips", 1f, 0.333f);
    }

    void SpawnShips()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 spawnPoint = new Vector2(Random.Range(min.x, max.x), max.y);

        Instantiate(ship, spawnPoint, Quaternion.identity);
    }
}
