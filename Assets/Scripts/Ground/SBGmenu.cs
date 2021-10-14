using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBGmenu : MonoBehaviour {

    Material material;
    Vector2 offset;
    Vector2 speed = new Vector2(0, 3);
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset = new Vector2(speed.x * Time.deltaTime, speed.y * Time.deltaTime);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
