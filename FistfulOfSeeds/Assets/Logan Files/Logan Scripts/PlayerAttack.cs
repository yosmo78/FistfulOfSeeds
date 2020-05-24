using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Animator animator;
    public Gizmos attackGizmo;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRange;
    public int damage;
    public int health = 3;
    private int healthRem = 0;
    public float invinciTime = 1;
    private float invinciTimeRem = 0;
    public bool invinciBool = false;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        healthRem = health;
        invinciTimeRem = invinciTime;
        GameObject healthUi = GameObject.Find("Health UI");
        DontDestroyOnLoad(healthUi);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            } 
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (timeBtwAttack <= 0)
        {
            // then you can attack
            if (Input.GetKey(KeyCode.Space))
            {
                //camAnim.SetTrigger("shake");
                //animator.SetTrigger("Attack");
                GameObject.Find("Attack").GetComponent<Animator>().SetTrigger("Attacking");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    try
                    {
                        enemiesToDamage[i].GetComponent<enemy1Path>().TakeDamage(damage);
                    }
                    catch
                    {
                        Debug.LogError("enemy not found");
                    }
                    try
                    {
                        enemiesToDamage[i].GetComponent<Enemy_Damage>().TakeDamage(damage);
                    }
                    catch
                    {
                        Debug.LogError("enemy not found");
                    }
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

    public void Hurt()
    {
        if(invinciBool == false)
        {
            health--;
            invinciBool = true;
            animator.SetBool("isHurt", true);
            animator.SetTrigger("Hurt");

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                health = healthRem;
                invinciBool = false;
                invinciTime = invinciTimeRem;
                this.transform.position = startPos;
                animator.SetBool("isHurt", false);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemy1Path enemy1 = collision.collider.GetComponent<enemy1Path>();
        Enemy_Damage enemy2 = collision.collider.GetComponent<Enemy_Damage>();

        if (enemy1 != null || enemy2 != null)
        {
            Hurt();
        }
    }
}
