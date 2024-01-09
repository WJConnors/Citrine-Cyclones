using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    private Rigidbody2D rb;
    protected bool isGrounded;

    // Ground check variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        // Check if character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle horizontal movement only if the character is grounded
        if (isGrounded)
        {
            rb.velocity = new Vector2(GetMoveInput() * speed, rb.velocity.y);
        }

        // Handle jumping
        if (GetJumpInput() && isGrounded)
        {
            Jump();
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
    }
}