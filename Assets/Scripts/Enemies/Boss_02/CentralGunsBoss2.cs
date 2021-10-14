using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CentralGunsBoss2 : MonoBehaviour {

    public GameObject lazer;

	void Start ()
    {
        StartCoroutine(Fire());
	}

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(lazer, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(lazer, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(lazer, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(5f);

        }
    }
}
