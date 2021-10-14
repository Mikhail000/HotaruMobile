using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldFillAmount : MonoBehaviour
{
    Image image;
    float fillDuration;
    bool fillTrigger;//триггер можно ли заполнять поле

    GameObject shield;

    void Start()
    {
        shield = GameObject.FindGameObjectWithTag("ShieldTag");
        image = gameObject.GetComponent<Image>();
        image = gameObject.GetComponent<Image>();
        fillDuration = 5;
    }

    void Update()
    {
        if (shield.activeInHierarchy == true)
        {
            fillTrigger = true;
        }
        if (fillTrigger)
        {
            image.fillAmount += 1 / fillDuration * Time.deltaTime;
            if (shield.GetComponent<ShieldClass>().theyCollisioned == true/*что то, что будет призываться, когда щит и дроп сталкиваются*/)
            {
                image.fillAmount = 0;
                image.fillAmount += 1 / fillDuration * Time.deltaTime;
            }
            if (image.fillAmount == 1)
            {
                image.fillAmount = 0;
                fillTrigger = false;
            }
        }
    }
}
