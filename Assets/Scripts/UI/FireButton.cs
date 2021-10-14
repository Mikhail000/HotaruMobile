using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    private PlayerScript playerPref;

    public void Fire()
    {
        playerPref = GameObject.FindObjectOfType<PlayerScript>();
        playerPref.PlayerShooting();
    }
}
