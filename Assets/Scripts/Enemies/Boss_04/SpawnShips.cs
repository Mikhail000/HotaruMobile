using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShips : MonoBehaviour {

    public GameObject Ship;

    void Start()
    {
        StartCoroutine(SpawnShip());
    }

    IEnumerator SpawnShip()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Instantiate(Ship, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Instantiate(Ship, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
