using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cannon : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Audiomanager.instance.PlayExplosion();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
