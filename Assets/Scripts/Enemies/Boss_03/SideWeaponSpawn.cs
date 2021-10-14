using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWeaponSpawn : MonoBehaviour {

    public GameObject Lazer;

    void Start()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Lazer, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(Lazer, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(Lazer, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            yield return new WaitForSeconds(2.5f);
        }
    }
}
