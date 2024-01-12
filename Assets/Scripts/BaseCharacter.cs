using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] [Range(5f, 15f)] private float speed = 10.0f;
    [SerializeField] [Range(1f, 20f)] private float jumpForce = 10.0f;
    private Rigidbody2D rb;
    protected bool isGrounded;
    public bool isClimbing;

    // Ground check variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    [SerializeField] [Range(1f, 2f)] private float userGravityScale = 1.5f;

    [HideInInspector] public UnityEvent OnPlayerJump;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        // Check if character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        rb.velocity = new Vector2(GetMoveInput() * speed, rb.velocity.y);

        // Handle jumping
        if (GetJumpInput() && isGrounded)
        {
            Jump();
        }

        if (isClimbing)
        {
            rb.gravityScale = 0;
            if (GetJumpInput())
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
        else
        {
            rb.gravityScale = userGravityScale;
        }
    }

    protected virtual float GetMoveInput()
    {
        // Default input method (can be overridden)
        return Input.GetAxis("Horizontal");
    }

    protected virtual bool GetJumpInput()
    {
        // Default jump input method (can be overridden)
        return Input.GetButtonDown("Jump");
    }

    protected void Jump()
    {
        // Apply jump force
        rb.velocity = new Vector2(GetMoveInput() * speed, jumpForce);
        OnPlayerJump?.Invoke();
    }
}