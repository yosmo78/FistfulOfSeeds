using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Path : MonoBehaviour
{
    public int health;
    public float speed;
    private float startSpeed;
    public float distance;
    private float dazedTime;
    public float startDazedTime;

    private bool movingRight = true;
    //public GameObject bloodEffect;

    public Transform groundDetection;

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

        //2020/5/28 update
        //alan: make it possible to change direction by any logic
        if (health % 2 == 1)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else { transform.Translate(Vector2.right * speed * Time.deltaTime); }
        

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}

    