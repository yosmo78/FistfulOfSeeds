using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logan_player_controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private float verticalMotion;
    public float bulletForce = 20f;


    public Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public float checkRadius;
    private static bool existsInScene;
    private int extraJumps;
    public int extraJumpsValue;
    public float startTimeBtwAttack;
    private float timeBtwAttack = 0;


    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera cam;
    public BoxCollider2D player;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    Vector2 mousePos;

    public static bool existsInScene;

    /* initialize to false so that no other controllers are made*/
    static logan_player_controller()
    {
        existsInScene = false;
    }

    void Start()
    {
        player = GetComponent<BoxCollider2D>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        if (!existsInScene)
        {
            existsInScene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - (Vector2)firePoint.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg;
        Debug.Log(angle);
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.DownArrow) == false)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("isCrouching", false);
            player.size = new Vector2(0.1845391f, 0.22387f);
            player.offset = new Vector2(-0.01120692f, -0.04815573f);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * 0, rb.velocity.y); ;
        }

        if (facingRight == false && (angle < 90 && angle > -90))
        {
            Flip();
        }
        else if (facingRight == true && (angle > 90 || angle <-90))
        {
            Flip();
        }
    }

    void Update()
    {
        if (!rb.bodyType.Equals(RigidbodyType2D.Static))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (timeBtwAttack <= 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                   Shoot();
                   timeBtwAttack = startTimeBtwAttack;
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
            if (rb.velocity.y < 0)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
            }

            if (moveInput != 0)
            {
                animator.SetFloat("Speed", 1);
            }
            if (moveInput == 0)
            {
                animator.SetFloat("Speed", 0);
            }
            
            if (isGrounded == true)
            {
               extraJumps = extraJumpsValue;
               if (rb.velocity.y <= 0)
               { 
                   animator.SetBool("isJumping", false);
                   animator.SetBool("isFalling", false);
               }
            }
            
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                animator.SetBool("isFalling", false);
                animator.SetBool("isJumping", true);
                animator.SetBool("isCrouching", false);
            }
            
            else if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
                animator.SetBool("isCrouching", false);
            }
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("isCrouching", true);
                player.size = new Vector2(0.1845391f, 0.112f);
                player.offset = new Vector2(0.018f, -0.1f);
            }
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
