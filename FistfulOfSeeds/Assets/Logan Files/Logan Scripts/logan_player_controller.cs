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

    private Rigidbody2D rb;
    public BoxCollider2D player;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private static bool existsInScene;

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

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
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
            if (rb.velocity.y <= 0)
            { 
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", true);
            animator.SetBool("isCrouching", false);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
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

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
