using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logan_player_controller : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float jumpForce;
    private float moveInput;
    private float verticalMotion;

    public Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public static bool existsInScene;

    /* initialize to false so that no other controllers are made*/
    static logan_player_controller()
    {
        existsInScene = false;
    }

    void Start()
    {
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
        if (!rb.bodyType.Equals(RigidbodyType2D.Static)) //make sure the player is allowed to move
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            animator.SetFloat("Speed", Mathf.Abs(moveInput));

            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }
    }

    void Update()
    {
        if (!rb.bodyType.Equals(RigidbodyType2D.Static))
        {
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
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                animator.SetBool("isFalling", false);
                animator.SetBool("isJumping", true);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("isJumping", true);
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
