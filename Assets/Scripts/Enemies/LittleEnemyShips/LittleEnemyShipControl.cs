using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnemyShipControl : MonoBehaviour {

    GameObject gamescore;
    [HideInInspector] public float speed;
    public GameObject ExplosionOfEnemy;

	void Start ()
    {
        gamescore = GameObject.FindGameObjectWithTag("ScoreTextTag");
        speed = 3f;
	}
	
	void FixedUpdate ()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0));

        if(transform.position.y < min.y)
        {     
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerLazerTag") || (col.tag == "ShieldTag"))
        {
            Destroy(gameObject);
            EnemyShipExplosion();
            gamescore.GetComponent<GameScore>().Score += 100;
        }
    }
    void EnemyShipExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionOfEnemy);
        explosion.transform.position = transform.position;
    }
}
