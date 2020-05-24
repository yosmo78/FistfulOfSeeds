using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        int enemyBulletLayer = LayerMask.NameToLayer("EnemyBullet");
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(enemyBulletLayer, enemyLayer, true);
        Physics2D.IgnoreLayerCollision(enemyBulletLayer, enemyBulletLayer, true);
        PlayerAttack player = collision.collider.GetComponent<PlayerAttack>();
        
        try
        {
            player.Hurt();
        }
        catch
        {
            Debug.LogError("player not found");
        }

        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}