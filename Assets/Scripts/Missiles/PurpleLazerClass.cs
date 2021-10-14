using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleLazerClass : MonoBehaviour {

    float speed;
    public GameObject ExplosionLazer;

    void Start()
    {
        speed = 9f;
        Destroy(gameObject, 5);
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
    }

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionLazer);
        explosion.transform.position = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "ShieldTag"))
        {
            Destroy(gameObject);
            Explosion();
        }
    }
}
