using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingEnemyShoot : MonoBehaviour
{
    public float timeBtwnShoot;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Transform firePoint;
    private float shootTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = GameObject.Find("Player").transform.position;
        Vector2 targetDir = targetPosition - firePoint.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(targetPosition);

        if (shootTime <= 0)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

            shootTime = timeBtwnShoot;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }
    }
}