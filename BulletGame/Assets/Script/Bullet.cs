using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody BRb;
    public float speed = 8f;

    void Start()
    {
        BRb = GetComponent<Rigidbody>();
        BRb.velocity = transform.forward * speed;

        Destroy(gameObject, 5f);
    }

    // 콜라이더 충돌 시 호출
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController PCtr = other.GetComponent<PlayerController>();

            if (PCtr != null)
            {
                PCtr.Die();
            }
        }
    }
}
