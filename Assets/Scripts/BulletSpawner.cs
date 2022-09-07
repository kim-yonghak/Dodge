using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float maxRate = 3f; 
    public float minRate = 0.5f;

    private float rate; 
    private Transform target; 
    private float timeAfterSpawn; 
    void Start()
    {
        rate = Random.Range(minRate, maxRate);
        target = FindObjectOfType<PlayerController>().transform;
        timeAfterSpawn = 0f;
    }

    void Update()
    {
       
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn > rate)
        {
            timeAfterSpawn = 0f;
            rate = Random.Range(minRate, maxRate);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target); 
        }
    }
}

