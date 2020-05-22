using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public int health;
    public float speed;
    private float startSpeed;
    private float dazedTime;
    public float startDazedTime;

    public void TakeDamage(int damage)
    {
        //play a hurt sound
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("damage TAKEN !");
    }

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = speed;
        dazedTime = 0;
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
            Destroy(gameObject);
        }

    }
}
