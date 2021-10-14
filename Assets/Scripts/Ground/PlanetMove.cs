using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour {

    private float speed;

    private void Start()
    {
        speed = 0.3f;
    }

    void Update ()
    {

        transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        if (transform.position.y >= 3)
        {
            speed = -speed;
        }
        if (transform.position.y <= 2)
        {
            speed = 0.3f;
        }
	}
}
