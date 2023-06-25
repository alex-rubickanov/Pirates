using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawnner : MonoBehaviour
{
    [SerializeField] GameObject enemy2Obj;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 2f;
    float randomSpawnTime;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

   IEnumerator SpawnEnemy()
    {
        while (true)
        {
            randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(minSpawnTime);
            Instantiate(enemy2Obj, transform.position, Quaternion.identity);
        }
    }
}
