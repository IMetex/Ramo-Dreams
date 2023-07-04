using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Access
    private GroundCheck groundCheck;
    private AnimationState animationState;

    [HideInInspector] public Rigidbody2D rb2D;
    [HideInInspector] public float horizontalInput; // X direction

    [Header("Player Value")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

        //Acces 
        groundCheck = GetComponent<GroundCheck>();
        animationState = GetComponent<AnimationState>();
    }
    private void Update()
    {
        Move();
        Jump();

        // Animation State 
        animationState.UpdateAnimationState();
    }

    private void Move()
    {
        // We move the character in the X direction
        horizontalInput = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(horizontalInput * moveSpeed, rb2D.velocity.y);
    }
    private void Jump()
    {
        // Character Jump 
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.IsGrounded())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

}
