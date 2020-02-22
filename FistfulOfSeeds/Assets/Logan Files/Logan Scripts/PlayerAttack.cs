﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Animator animator;
    public float attackRange;
    public int damage;
    public int health = 3;
    private int healthRem = 0;
    public float invinciTime = 2;
    private float invinciTimeRem = 0;
    public bool invinciBool = false;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        healthRem = health;
        invinciTimeRem = invinciTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            // then you can attack
            if (Input.GetKey(KeyCode.Space))
            {
                //camAnim.SetTrigger("shake");
                animator.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<enemy1Path>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (invinciBool == true)
        {
            int enemyLayer = LayerMask.NameToLayer("Enemy");
            int playerLayer = LayerMask.NameToLayer("Player");
            Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, true);
            invinciTime -= Time.deltaTime;

            if (invinciTime <= 0)
            {
                invinciTime = invinciTimeRem;
                invinciBool = false;
                animator.SetBool("isHurt", false);
                Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void Hurt()
    {
        if(invinciBool == false)
        {
            health--;
            invinciBool = true;
            animator.SetBool("isHurt", true);

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                health = healthRem;
                invinciBool = false;
                this.transform.position = startPos;
                animator.SetBool("isHurt", false);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemy1Path enemy = collision.collider.GetComponent<enemy1Path>();

        if (enemy != null)
        {
            Hurt();
        }
    }
}
