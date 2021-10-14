using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLazerPlayer : MonoBehaviour {

    float speed;
    [HideInInspector]
    public float Damage;
    public GameObject LazerExplosion;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShipTag");
        speed = 8;
    }

    void Update()
    {
        Damage = player.GetComponent<PlayerScript>().setDamage;
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(LazerExplosion);
        explosion.transform.position = transform.position;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "BossShip") || 
            (col.tag == "BossShip2") || (col.tag == "MeteorTag"))
        {
            Destroy(gameObject);
            Explosion();
        }
    }
}
