using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int maxEnemiesAmount;
    [SerializeField] private int enemyCount;
    [SerializeField] private GameObject enemyPrefab;

    private void Update()
    {
        if (enemyCount < maxEnemiesAmount)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
        enemyCount++;
    }
}
