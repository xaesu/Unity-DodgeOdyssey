using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject[] bulletPrefab;

    public float RateMin = 0.5f;
    public float RateMax = 5f;

    Transform target;
    float spawnRate;
    float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(RateMin, RateMax); 

        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            int bulletIndex = Random.Range(0, bulletPrefab.Length);
            GameObject bullet = Instantiate(bulletPrefab[bulletIndex], transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(RateMin, RateMax);
        }
    }
}
