using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject leftEnemyPrefab;
    [SerializeField] private GameObject rightEnemyPrefab;

    private void Start()
    {
        SpawnEnemy(true);
        SpawnEnemy(false);
    }
    public void SpawnEnemy(bool leftOrRight)
    {
        StartCoroutine(SpawnEnemyC(leftOrRight));
    }
    private IEnumerator SpawnEnemyC(bool leftOrRight)
    {
        yield return new WaitForSeconds(2f);

        if(leftOrRight) {
            Instantiate(rightEnemyPrefab, this.transform);
        } else {
            Instantiate(leftEnemyPrefab, this.transform);
        }
    }
}
