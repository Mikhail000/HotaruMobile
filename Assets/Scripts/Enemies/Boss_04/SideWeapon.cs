using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWeapon : MonoBehaviour {

    GameObject targetTransform;
    [HideInInspector]
    public float speed;

    void Start()
    {
        speed = 5f;
        targetTransform = GameObject.FindGameObjectWithTag("PlayerShipTag");
    }

    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            Vector3 vectorToTarget = targetTransform.transform.position - transform.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, Time.deltaTime * speed);
            Vector3 euler = transform.eulerAngles;
            if (euler.z > 180) euler.z = euler.z - 360;
            euler.z = Mathf.Clamp(euler.z, -28, 28);
            transform.eulerAngles = euler;
        }
    }
}
