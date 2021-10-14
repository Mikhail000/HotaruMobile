using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGo : MonoBehaviour {

    public GameObject bullet;

    void Start()
    {
        Invoke("Fire", 0.2f);
    }

    void Fire()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
