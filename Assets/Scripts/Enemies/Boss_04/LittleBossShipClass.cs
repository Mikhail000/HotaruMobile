using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBossShipClass : MonoBehaviour {

    float speed;
    int Helthi;

    public GameObject explos;

    void Start()
    {
        speed = 3;
        Helthi = 4;
    }

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

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(explos);
        explosion.transform.position = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerLazerTag") || (col.tag == "ShieldTag"))
        {
            Helthi -= 1;
            if (Helthi == 0)
            {
                Destroy(gameObject);
                Explosion();
            }
        }
    }
}
