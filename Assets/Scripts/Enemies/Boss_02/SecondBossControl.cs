using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondBossControl : MonoBehaviour {
    GameObject gamescore;

    [HideInInspector]
    float speed;
    public GameObject bullet;
    public Slider bar;
    [HideInInspector]
    float MaxHealth;
    [HideInInspector]
    float CurrentHealth;
    [HideInInspector]
    float AvailableHealth;

    GameObject shieldBoss;
    public Slider shieldbar;

    public GameObject BossExplosion;

    private Transform target;

    float speedCome = 2f;

    void Start ()
    {
        speed = 2f;
        MaxHealth = 1500f;
        CurrentHealth = MaxHealth;

        shieldBoss = GameObject.Find("shieldEn");

        gamescore = GameObject.FindGameObjectWithTag("ScoreTextTag");
        target = GameObject.FindGameObjectWithTag("PlayerShipTag").GetComponent<Transform>();
	}
	
	void FixedUpdate ()
    {
        BossCome();

        if(Vector2.Distance(transform.position, target.position) > 0)
        {
            Vector2 targetPos = target.transform.position;
            Vector2 position = transform.position;
            position = new Vector2(position.x, position.y);
            transform.position = Vector2.MoveTowards(position, new Vector2(targetPos.x, transform.position.y), speed * Time.deltaTime);
        }
		
	}

    void DealDamage()
    {
        float DMG = bullet.GetComponent<ControlLazerPlayer>().Damage;
        CurrentHealth -= DMG;
    }

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(BossExplosion);
        explosion.transform.position = transform.position;

    }

    void SummonShield()
    {
        shieldBoss.SetActive(true);
        shieldbar.value = 100;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerLazerTag"))
        {
            DealDamage();
            bar.value = CurrentHealth;        
            if (bar.value <= 1)
            {
                Destroy(gameObject);
                gamescore.GetComponent<GameScore>().Score += 1000;
                Explosion();
            }
            if (bar.value == 750)
            {
                SummonShield();
            }
        }
    }

    void BossCome()
    {
        transform.Translate(Vector3.down * speedCome * Time.deltaTime);
        if (transform.position.y <= 2.43f)
        {
            speedCome = 0f;
        }
    }
}
