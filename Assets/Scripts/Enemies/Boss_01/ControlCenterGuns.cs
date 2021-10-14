using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCenterGuns : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        StartCoroutine(Fire());       
    }


    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3.5f);           
        }
    }
}
