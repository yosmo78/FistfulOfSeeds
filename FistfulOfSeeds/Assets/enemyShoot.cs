using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public float timeBtwnShoot;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    private float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        firePoint1.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        firePoint2.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        firePoint3.rotation = Quaternion.AngleAxis(180, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTime <= 0)
        {
            
            GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(firePoint1.right * bulletForce, ForceMode2D.Impulse);

            GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint3.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint2.right * bulletForce, ForceMode2D.Impulse);

            GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePoint3.right * bulletForce, ForceMode2D.Impulse);

            shootTime = timeBtwnShoot;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }
        
          
        
    }
}
