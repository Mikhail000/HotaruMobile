using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBG : MonoBehaviour
{
    Material material;
    Vector2 offset;
    private Vector2 speedBG = new Vector2(0, 5);
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset = new Vector2(speedBG.x * Time.deltaTime, speedBG.y * Time.deltaTime);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}