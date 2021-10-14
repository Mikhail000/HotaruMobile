using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrSpawner : MonoBehaviour {

    public GameObject BossBullet;

    void Start()
    {
        InvokeRepeating("FireBossBullet", 1f, 3f);
    }

    void FireBossBullet()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("PlayerShipTag");
        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(BossBullet);
            bullet.transform.position = transform.position;
            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<BallControl>().SetDirection(direction);
        }
    }
}
