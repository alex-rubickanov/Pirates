using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBullet : MonoBehaviour
{
    [SerializeField] Transform boatPos;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float minTime = 3f;
    [SerializeField] float maxTime = 8f;
    float randomSpawn;
    int randomPos;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            randomSpawn = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(randomSpawn);
            randomPos = Random.Range(0, spawnPoints.Length);
            GameObject bulletObj = Instantiate(bullet, spawnPoints[randomPos].position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bulletObj.GetComponent<Rigidbody2D>();
            Vector2 direction = (boatPos.position - spawnPoints[randomPos].position).normalized;
            bulletRigidbody.velocity = direction * bulletSpeed;
            Destroy(bulletObj, 15f);
        }
    }
}
