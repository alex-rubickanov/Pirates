using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHoles : MonoBehaviour
{
    [SerializeField] Transform[] holes;
    [SerializeField] GameObject damageSpot;
    [SerializeField] int randomPos;
    [SerializeField] int percentToSpawn;
    public void SpawnHole()
    {
        percentToSpawn = Random.Range(0, 2);

        if(percentToSpawn > 0)
        {
            randomPos = Random.Range(0, holes.Length);
            Instantiate(damageSpot, holes[randomPos].position, Quaternion.identity);
        }
    }
}
