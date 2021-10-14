using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthBossControl : MonoBehaviour {

    GameObject gamescore;

    float speed;
    float speedCome = 2f;
    float getout;
    bool canSpawn = true;

    public GameObject bullet;
    public Slider bar;
    [HideInInspector]
    public float MaxHealth;
    [HideInInspector]
    public float CurrentHealth;
    [HideInInspector]
    public float AvailableHealth;

    public GameObject BossExplosion;

    private Transform target;

    public GameObject FinalyShip;

    public void Start()
    {
        getout = 0.8f;
        speed = 1f;
        MaxHealth = 2000f;
        CurrentHealth = MaxHealth;

        gamescore = GameObject.FindGameObjectWithTag("ScoreTextTag");
        target = GameObject.FindGameObjectWithTag("PlayerShipTag").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        BossCome();

        GetOutOfHere();
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > 0)
            {
                Vector2 targetPos = target.transform.position;
                Vector2 position = transform.position;
                position = new Vector2(position.x, position.y);
                transform.position = Vector2.MoveTowards(position, new Vector2(targetPos.x, transform.position.y), speed * Time.deltaTime);
            }
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

    void GetOutOfHere()
    {
        if(CurrentHealth <= 500)
        {
            Destroy(gameObject, 2.5f);
            transform.Translate(0, getout * Time.deltaTime, 0, Space.World);
            GameObject spawnShips = GameObject.Find("ShipPointSpawn");
            Destroy(spawnShips);
            GameObject spawnObject = GameObject.Find("FinalySpawnPoint");
            Vector2 spawnPoint = spawnObject.GetComponent<Transform>().position;
            if (canSpawn)
            {
                Instantiate(FinalyShip, spawnPoint, Quaternion.identity);
                canSpawn = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerLazerTag"))
        {
            DealDamage();
            bar.value = CurrentHealth;
            if (bar.value <= 1)
            {
                Destroy(gameObject);
                gamescore.GetComponent<GameScore>().Score += 1000;
                Explosion();
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
