using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusBossBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        int cactusBossBulletLayer = LayerMask.NameToLayer("CactusBossBullet");
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerBulletLayer = LayerMask.NameToLayer("Bullet");
        Physics2D.IgnoreLayerCollision(cactusBossBulletLayer, enemyLayer, true);
        Physics2D.IgnoreLayerCollision(cactusBossBulletLayer, cactusBossBulletLayer, true);
        Physics2D.IgnoreLayerCollision(cactusBossBulletLayer, playerBulletLayer, true);
        PlayerAttack player = collision.collider.GetComponent<PlayerAttack>();

        try
        {
            if(player != null)
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