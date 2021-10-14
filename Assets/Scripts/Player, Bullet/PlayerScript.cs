using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Joystick joystick;
    private Button fireButton;

    [HideInInspector]
    public Vector2 speedPlayer = new Vector2(10, 10);
    [HideInInspector]
    public float setDamage;
    Rigidbody2D rb;
    Vector2 movement;
    [HideInInspector]
    public GameObject LazerPlayer;
    public GameObject LazerPlayerPosition;
    public GameObject PlayerExplosion;

    private ParticleSystem firstHpParticles;
    private ParticleSystem secondHpParticles;

    [Header("Baffs")]

    GameObject shield;
    GameObject acceleration;
    GameObject doubleDamage;

    [HideInInspector]
    public Text LivesUIText;

    [HideInInspector]
    public int MaxLives = 10;
    [HideInInspector]
    public int HP;

    void Start()
    {
        shield = GameObject.Find("Shield");
        shield.SetActive(false);
        acceleration = GameObject.Find("Acceleration");
        acceleration.SetActive(false);
        doubleDamage = GameObject.Find("DoubleDamage");
        doubleDamage.SetActive(false);

        joystick = GameObject.FindObjectOfType<Joystick>();

        //Find health particles components
        firstHpParticles = GameObject.Find("LightHeartParticles").GetComponent<ParticleSystem>();
        secondHpParticles = GameObject.Find("DarkHeartParticles").GetComponent<ParticleSystem>();

        LivesUIText = GameObject.Find("NumbLives").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        HP = MaxLives;
        LivesUIText.text = HP.ToString();
        setDamage = 5;
    }

    void FixedUpdate()
    {      
        float X = joystick.Horizontal;      
        float Y = joystick.Vertical;

        Vector2 movement = new Vector2(X, Y);
        //rb.velocity = movement;
        ScreenLimitation(movement);
        //PlayerShooting();

        if (HP >= 10) HP = 10;
        LivesUIText.text = HP.ToString();

        LazerPlayer.GetComponent<ControlLazerPlayer>().Damage = setDamage;
    }

    public void PlayerShooting()
    {
        GetComponent<AudioSource>().Play();
        Vector2 lazerPos = LazerPlayerPosition.transform.position;
        Instantiate(LazerPlayer, lazerPos, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyLazerTag") || (col.tag == "BossBulletTag")
            || (col.tag == "BossShip") || (col.tag == "MeteorTag") || (col.tag == "FirstBossElectroBlast") || (col.tag == "BossShip2"))
        {
            HP--;
            LivesUIText.text = HP.ToString();
            if (HP == 0)
            {
                gameObject.SetActive(false);
            }
        }

        //колизия игрок - дроп щита
        if (col.tag == "ShieldDropTag")
        {
            shield.SetActive(true);
        }
        ////колизия игрок - дроп ДД
        if (col.tag == "DoubledamageTag")
        {
            doubleDamage.SetActive(true);
            setDamage = 10;
        }
        ////колизия игрок - дроп аптеки
        if (col.tag == "HelpfulDropTag")
        {
            StartCoroutine(ActiveHealthParticle());
        }
    }

    IEnumerator ActiveHealthParticle()
    {
        firstHpParticles.Play();
        secondHpParticles.Play();
        yield return new WaitForSeconds(firstHpParticles.main.startLifetime.constantMax);
        firstHpParticles.Stop();
        secondHpParticles.Stop();
    }

    void Explosion()
    {
        GameObject explosion = (GameObject)Instantiate(PlayerExplosion);
        explosion.transform.position = transform.position;
    }

    void ScreenLimitation(Vector2 movement)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.1f;
        min.x = min.x + 0.1f;

        max.y = max.y - 0.1f;
        min.y = min.y + 0.1f;

        Vector2 pos = transform.position;
        pos += movement * speedPlayer * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
