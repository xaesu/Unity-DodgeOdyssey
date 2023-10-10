using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBullet : MonoBehaviour
{
    Rigidbody BRb;
    public float speed = 8f;

    void Start()
    {
        BRb = GetComponent<Rigidbody>();
        BRb.velocity = transform.forward * speed;

        Destroy(gameObject, 3.5f);
    }

}
