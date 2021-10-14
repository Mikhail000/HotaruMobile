using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldClass : MonoBehaviour {

    [SerializeField]
    int Helth = 4;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "BossBulletTag") || (col.tag == "EnemyLazerTag") || (col.tag == "FirstBossElectoBlast") || (col.tag == "BossShip"))
        {
            Helth -= 1;
            if(Helth == 0)
            {
                gameObject.SetActive(false);
            }
        }        
    }

}
