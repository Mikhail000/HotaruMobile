using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometClass : MonoBehaviour {

    private float speed = 3f;
    private ParticleSystem particles;
    private SpriteRenderer sr;
    private CircleCollider2D bc;

    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<CircleCollider2D>();
    }

    private void Update ()
    {
        transform.Rotate(0, 0, 0.5f);
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "ShieldTag") ||(col.tag == "PlayerLazerTag"))
        {
            StartCoroutine(TheEnd());
        }

    }

    private IEnumerator TheEnd()
    {
        particles.Play();
        sr.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(particles.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
