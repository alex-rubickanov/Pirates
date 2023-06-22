using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatStatus : MonoBehaviour
{
    [SerializeField] public float boatHealth = 100f;
    [SerializeField] RandomHoles randomHoles;
    [SerializeField] Slider healthSlider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DamageBoat(10);
        }
    }
    public void DamageBoat(float damage)
    {
        randomHoles.SpawnHole();
        boatHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet") {
            Destroy(collision.gameObject);
        }
    }
}
