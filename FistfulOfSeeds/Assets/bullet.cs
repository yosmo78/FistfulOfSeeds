using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        int bulletLayer = LayerMask.NameToLayer("Bullet");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(bulletLayer, playerLayer, true);
        enemy1Path enemy1 = collision.collider.GetComponent<enemy1Path>();
        Enemy_Damage enemy2 = collision.collider.GetComponent<Enemy_Damage>();
   
        try
        {
           enemy1.TakeDamage(damage);
        }
        catch
        {
           Debug.LogError("enemy not found");
        }
        try
        {
           enemy2.TakeDamage(damage);
        }
        catch
        {
            Debug.LogError("enemy not found");
        }

        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
