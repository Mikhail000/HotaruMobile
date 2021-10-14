using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedFillAmount : MonoBehaviour
{
    Image image;
    float fillDurationAc;
    bool fillTrigger;//триггер можно ли заполнять поле

    GameObject acceleration;

    void Start()
    {
        acceleration = GameObject.FindGameObjectWithTag("AccelerationPlayerTag");
        image = gameObject.GetComponent<Image>();
        fillDurationAc = 5;
    }

    void Update()
    {
        if (acceleration.activeSelf == true)
        {
            fillTrigger = true;
        }
        if (fillTrigger)
        {
            image.fillAmount += 1 / fillDurationAc * Time.deltaTime;
            if(acceleration.GetComponent<AccelerationScript>().theyCollisioned == true)
            {
                image.fillAmount = 0;
                image.fillAmount += 1 / fillDurationAc * Time.deltaTime;
            }
            if (image.fillAmount == 1)
            {
                image.fillAmount = 0;
                fillTrigger = false;
            }
        }
    }
}
