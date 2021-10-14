using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitClass : MonoBehaviour {

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShipTag");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShipTag")
        {
            player = GameObject.FindGameObjectWithTag("PlayerShipTag");
            player.GetComponent<PlayerScript>().HP += 2;
            player.GetComponent<PlayerScript>().LivesUIText.text = player.GetComponent<PlayerScript>().HP.ToString();
        }
        
    }

}
