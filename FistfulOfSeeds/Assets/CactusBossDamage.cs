using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CactusBossDamage : MonoBehaviour
{
    public int health;
    public float speed;
    private float startSpeed;
    private float dazedTime;
    public float startDazedTime;

    public BossHealthUI healthBar;


    // Start is called before the first frame update
    void Start()
    {
        startSpeed = speed;
        dazedTime = 0;
        healthBar.SetMaxHealth(health);
    }


    public void TakeDamage(int damage)
    {
        //play a hurt sound
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        dazedTime = startDazedTime;
        health -= damage;
        healthBar.SetHealth(health);
        Debug.Log("damage TAKEN !");
    }
    

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
        {
            speed = startSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            FindObjectOfType<CameraFollow>().isFollowing = false;
            GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
            GlobalSceneChange.sceneFrom = SceneManager.GetActiveScene().name;
            Destroy(gameObject);
            SceneManager.LoadScene("EndScene");
        }

    }
}

