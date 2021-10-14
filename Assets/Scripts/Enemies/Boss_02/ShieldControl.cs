using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldControl : MonoBehaviour {

    public GameObject bullet;
    public Slider bar;
    [HideInInspector]
    public float MaxHealth;
    [HideInInspector]
    float CurrentHealth;
    [HideInInspector]
    float AvailableHealth;

    void Start ()
    {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
    }

    void DealDamage()
    {
        float DMG = bullet.GetComponent<ControlLazerPlayer>().Damage;
        CurrentHealth -= DMG;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerLazerTag"))
        {
            DealDamage();
            bar.value = CurrentHealth;
            if (bar.value <= 1)
            {
                gameObject.SetActive(false);
                CurrentHealth = 100f;
            }
        }
    }
}
