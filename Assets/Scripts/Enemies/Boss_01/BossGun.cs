using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{
    public GameObject BossBullet;
	
	void Start ()
    {
        InvokeRepeating("FireBossBullet", 2f, 2f);
	}
	
    void FireBossBullet()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("PlayerShipTag");
        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(BossBullet);
            bullet.transform.position = transform.position;
            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<SecondLazer>().SetDirection(direction);
        }
    }
}
