using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationScript : MonoBehaviour {

    [HideInInspector]
    public float activeDuration;
    [HideInInspector]
    public bool theyCollisioned;

    public ParticleSystem particles;
    float simParticlesSpeed;

    GameObject player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShipTag");
        theyCollisioned = false;
        activeDuration = 5.0f;
	}
	
	void Update ()
    {
        if (activeDuration >= 0.0f && gameObject.activeSelf == true)//проверка для счетчика после активации щита
        {
            theyCollisioned = false;
            activeDuration -= 1.0f * Time.deltaTime;
            if (activeDuration <= 0.0f)
            {
                gameObject.SetActive(false);
                player.GetComponent<PlayerScript>().speedPlayer = new Vector2(7, 7);
                activeDuration = 5.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AccelerationTag")
        {
            theyCollisioned = true;
            if (gameObject.activeSelf == true && activeDuration > 0.0f)//проверка для инициализации счетчика после колизии активного щита с дропом
            {
                player.GetComponent<PlayerScript>().speedPlayer = new Vector2(15, 15);
                activeDuration = 5.0f;
                if (activeDuration <= 0.0f)
                {
                    gameObject.SetActive(false);
                    player.GetComponent<PlayerScript>().speedPlayer = new Vector2(7, 7);
                }
            }
        }
    }
}
