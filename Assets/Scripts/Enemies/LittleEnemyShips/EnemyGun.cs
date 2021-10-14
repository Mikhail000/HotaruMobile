using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyLazer;

    void Start()
    {
        Invoke("FireEnemyLazer", 0.3f);
    }

    void FireEnemyLazer()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("PlayerShipTag");
        if(playerShip != null)
        {
            GameObject lazer = (GameObject)Instantiate(EnemyLazer);
            lazer.transform.position = transform.position;
            Vector2 direction = playerShip.transform.position - lazer.transform.position;
            lazer.GetComponent<EnemyLazer>().SetDirection(direction);
        }
    }
}
