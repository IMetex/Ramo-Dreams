using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum MoveAnimState { idle, running, jumping, falling }

    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private float horizontalInput;

    [SerializeField] private LayerMask jumpGrounded;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Move();
        Jump();
        UpdateAnimationState();

    }

    private void Move()
    {
        // We move the character in the X direction
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
    private void Jump()
    {    
        // Character Jump 
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void UpdateAnimationState()
    {
        MoveAnimState state;

        if (horizontalInput > 0 || horizontalInput < 0)
        {   
            // Running Animation
            sprite.flipX = horizontalInput < 0 ? true : false;
            state = MoveAnimState.running;
        }
        else
        {   // Idle Animation
            state = MoveAnimState.idle;
        }

        if (rb.velocity.y > .1f)
        {    
            // Jump Animation
            state = MoveAnimState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            // Fall Animation
            state = MoveAnimState.falling;
        }

        animator.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {   
        // We check if the character touches the ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGrounded);
    }
}
