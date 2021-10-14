using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDClass : MonoBehaviour
{
    [HideInInspector]
    public float activeDuration;
    [HideInInspector]
    public bool theyCollisioned;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShipTag");
        theyCollisioned = false;
        activeDuration = 2.50f;
    }

    void Update()
    {
        if (activeDuration >= 0.0f && gameObject.activeSelf == true)//проверка для счетчика после активации щита
        {
            theyCollisioned = false;
            activeDuration -= 1.0f * Time.deltaTime;
            if (activeDuration <= 0.0f)
            {
                gameObject.SetActive(false);
                player.GetComponent<PlayerScript>().setDamage = 5;
                activeDuration = 2.50f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DoubledamageTag")
        {
            theyCollisioned = true;
            if (gameObject.activeSelf == true && activeDuration > 0.0f)//проверка для инициализации счетчика после колизии активного щита с дропом
            {
                player.GetComponent<PlayerScript>().setDamage = 10;
                activeDuration = 2.50f;
                if (activeDuration <= 0.0f)
                {
                    gameObject.SetActive(false);
                    player.GetComponent<PlayerScript>().setDamage = 5;
                }
            }
        }
    }
}
