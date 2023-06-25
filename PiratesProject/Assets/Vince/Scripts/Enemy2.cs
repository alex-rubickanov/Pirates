using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float health = 20f;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform target;
    [SerializeField] float distanceFromPlayer;
    [SerializeField] float stoppingDistance = 2f;
    [Header("Shooting")]
    [SerializeField] Transform bulletSpawner;
    [SerializeField] float bulletSpeed = 2f;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate = 0.1f;
    [Header("Particle")]
    [SerializeField] GameObject explosion;
    float currentTime;
    float moveSteps;
    void Start()
    {
        target = GameObject.Find("Boat").transform;
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
        LookAtPlayer();
        DeathHandler();
    }
    private void GoToPlayer()
    {
        if(target != null)
        {
            moveSteps = speed * Time.deltaTime;
            distanceFromPlayer = Vector3.Distance(transform.position, target.position);

            if(stoppingDistance < distanceFromPlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSteps);
            }
            else
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if(currentTime < fireRate)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        GameObject bulletObj = Instantiate(bullet, bulletSpawner.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bulletObj.GetComponent<Rigidbody2D>();
        Vector2 direction = (target.position - bulletSpawner.position).normalized;
        bulletRigidbody.velocity = direction * bulletSpeed;
    }

    private void LookAtPlayer()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
    }

    private void DeathHandler()
    {
        if(health <= 0)
        {
            GameObject explosionObj = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionObj, 1f);
            Audiomanager.instance.PlayExplosion();
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            health -= 10f;
            Destroy(collision.gameObject);
        }
    }
}
