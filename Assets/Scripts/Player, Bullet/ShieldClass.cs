using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldClass : MonoBehaviour
{
    [HideInInspector]
    public float activeDuration;
    [HideInInspector]
    public bool theyCollisioned;

    void Start()
    {
        theyCollisioned = false;
        activeDuration = 5.0f;
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
                activeDuration = 5.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ShieldDropTag")
        {
            theyCollisioned = true;
            if (gameObject.activeSelf == true && activeDuration > 0.0f)//проверка для инициализации счетчика после колизии активного щита с дропом
            {
                activeDuration = 5.0f;
                if (activeDuration <= 0.0f)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
