using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFinalShip : MonoBehaviour
{

    float speed;
    public GameObject explos;

    IEnumerator Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShipTag");
        speed = 2;

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Explosion();
        //player.GetComponent<PlayerScript>().HP = 0;
        Destroy(player);
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
    }

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(explos);
        explosion.transform.position = transform.position;
    }
}
