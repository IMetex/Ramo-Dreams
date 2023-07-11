using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Access
    private GroundCheck groundCheck;
    private Animator animator;
    [HideInInspector] public SpriteRenderer sprite;
    [HideInInspector] public Rigidbody2D rb2D;

    private float horizontalInput; // X direction

    [Header("Player Value")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //Acces 
        groundCheck = GetComponent<GroundCheck>();
    }
    private void Update()
    {
        Move();
        Jump();
        CheckFall();

    }

    private void Move()
    {
        // We move the character in the X direction
        horizontalInput = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(horizontalInput * moveSpeed, rb2D.velocity.y);

        if (horizontalInput > 0 || horizontalInput < 0)
        {
            // Sprite left and right  move
            sprite.flipX = horizontalInput < 0 ? true : false;
            animator.SetBool("IsRunning", true);
        }
        else
        {   // Idle Animation
            animator.SetBool("IsRunning", false);
        }
    }

    private void Jump()
    {
        // Character Jump 
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.IsGrounded())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }


        if (rb2D.velocity.y > .1f)
        {
            // Jump Animation
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

    }

    private void CheckFall()
    {
        if (rb2D.velocity.y < -.1f)
        {
            // Fall Animation
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }

    }

}
