using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour {

    public GameObject medkit;
    public GameObject shieldDrop;
    public GameObject doubledamage;
    
    int randomValue;

    private void Start()
    {
        InvokeRepeating("LootIdentification", 0.2f, 4.5f);
    }

    void LootIdentification()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 position = new Vector2(Random.Range(min.x, max.x), max.y);

        randomValue = Random.Range(1, 100);
        if (randomValue >= 30 && randomValue <= 100)
        {
            //instantiate medkit
            Instantiate(medkit, position, Quaternion.identity);
        }
        else if (randomValue < 29 && randomValue >= 10)
        {
            Instantiate(shieldDrop, position, Quaternion.identity);
        }
        else if (randomValue < 9 && randomValue >= 1)
        {
            //instantiate doubledamage
            Instantiate(doubledamage, position, Quaternion.identity);
        }
    }
     
}
