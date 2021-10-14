using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSceneryMenu : MonoBehaviour {

    public GameObject meteor;

    private void Start()
    {
        InvokeRepeating("SpawnShip", 1f, 3f);
    }

    void SpawnShip()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        GameObject enShip = (GameObject)Instantiate(meteor);
        enShip.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
