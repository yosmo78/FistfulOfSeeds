using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactusBossAttack : MonoBehaviour
{
    public float timeBtwnShoot1;
    public float timeBtwnShoot2;
    public float timeBtwnShoot3;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    private bool shoot1Turn;
    private bool shoot2Turn;
    private float shootTime1;
    private float shootTime2;
    private float shootTime3;

    // Start is called before the first frame update
    void Start()
    {
        firePoint1.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        firePoint2.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        firePoint3.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        shootTime1 = timeBtwnShoot1;
        shootTime2 = timeBtwnShoot2;
        shootTime3 = timeBtwnShoot3;
        shoot1Turn = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = GameObject.Find("Player").transform.position;
        Vector2 targetDir = targetPosition - firePoint4.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        firePoint4.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(targetPosition);

        if ((shootTime1 <= 0) && (shoot1Turn == true))
        {

            GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(firePoint1.right * bulletForce, ForceMode2D.Impulse);

            shoot1Turn = false;
            shoot2Turn = true;
            shootTime1 = timeBtwnShoot1;
        }
        else if(shoot1Turn == true)
        {
            shootTime1 -= Time.deltaTime;
        }

        if ((shootTime2 <= 0) && (shoot2Turn == true))
        {
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint3.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint2.right * bulletForce, ForceMode2D.Impulse);

            GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePoint3.right * bulletForce, ForceMode2D.Impulse);

            shoot1Turn = true;
            shoot2Turn = false;
            shootTime2 = timeBtwnShoot2;
        }
        else if (shoot2Turn == true)
        {
            shootTime2 -= Time.deltaTime;
        }

        if (shootTime3 <= 0)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint4.right * bulletForce, ForceMode2D.Impulse);

            shootTime3 = timeBtwnShoot3;
        }
        else
        {
            shootTime3 -= Time.deltaTime;
        }



    }
}