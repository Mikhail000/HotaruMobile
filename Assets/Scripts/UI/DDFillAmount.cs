using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDFillAmount : MonoBehaviour {

    Image image;
    float fillDuration;
    bool fillTrigger;//триггер можно ли заполнять поле

    GameObject doubledamage;

    void Start()
    {
        doubledamage = GameObject.FindGameObjectWithTag("DDPlayerTag");
        image = gameObject.GetComponent<Image>();
        image = gameObject.GetComponent<Image>();
        fillDuration = 2.50f;
    }

    void Update()
    {
        if (doubledamage.activeInHierarchy == true)
        {
            fillTrigger = true;
        }
        if (fillTrigger)
        {
            image.fillAmount += 1 / fillDuration * Time.deltaTime;
            if (doubledamage.GetComponent<DDClass>().theyCollisioned == true/*что то, что будет призываться, когда щит и дроп сталкиваются*/)
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
