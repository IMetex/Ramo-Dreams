using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    private enum MoveAnimState { idle, running, jumping, falling }
    private SpriteRenderer sprite;
    private Animator animator;
    private PlayerController playerController;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    public void UpdateAnimationState()
    {
        MoveAnimState state;
          
        // Running and Idle Animmation
        if (playerController.horizontalInput > 0 || playerController.horizontalInput < 0)
        {
            // Sprite left and right  move
            sprite.flipX = playerController.horizontalInput < 0 ? true : false;
            // Running Animation
            state = MoveAnimState.running;
        }
        else
        {   // Idle Animation
            state = MoveAnimState.idle;
        }

         // Jump and Fall Animation
        if (playerController.rb2D.velocity.y > .1f)
        {
            // Jump Animation
            state = MoveAnimState.jumping;
        }
        else if (playerController.rb2D.velocity.y < -.1f)
        {
            // Fall Animation
            state = MoveAnimState.falling;
        }

        animator.SetInteger("State", (int)state);
    }
}
