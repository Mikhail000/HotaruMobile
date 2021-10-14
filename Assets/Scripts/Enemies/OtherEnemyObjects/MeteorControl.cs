﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour
{

    float speed = 2f;
    public GameObject ExplosionofMeteor;

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "ShieldTag"))
        {
            MeteorExplosion();
            Destroy(gameObject);
        }
      
    }
    void MeteorExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionofMeteor);
        explosion.transform.position = transform.position;
    }

}
