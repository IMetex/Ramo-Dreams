using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpGrounded;
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }
    
    public  bool IsGrounded()
    {
        // We check if the character touches the ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGrounded);
    }
}
