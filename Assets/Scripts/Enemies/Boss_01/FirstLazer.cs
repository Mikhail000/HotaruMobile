using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLazer : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    public GameObject LazerExplosion;

    void Awake()
    {
        speed = 10f;
        isReady = false;
    }

    void FixedUpdate()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x)
                || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;

    }

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(LazerExplosion);
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

