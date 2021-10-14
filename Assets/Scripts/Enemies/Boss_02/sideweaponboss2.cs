using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideweaponboss2 : MonoBehaviour
{
    GameObject target;
    float speed;

    private void Start()
    {
        speed = 3f;
        target = GameObject.FindGameObjectWithTag("PlayerShipTag");
    }
    void FixedUpdate()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, Time.deltaTime * speed);
        Vector3 euler = transform.eulerAngles;
        if (euler.z > 180) euler.z = euler.z - 360;
        euler.z = Mathf.Clamp(euler.z, -5, 5);
        transform.eulerAngles = euler;

    }
}
