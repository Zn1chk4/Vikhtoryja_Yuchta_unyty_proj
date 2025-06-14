using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 7;
    public float jumpForce = 300;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public GroundChecker groundChecker;
    public PlayerHealth health;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (health.isDead)
        {
            anim.SetBool("IsRun", false);
            anim.SetBool("IsJumping", false);
            return;
        }

        if (!health.canMove) return;

        if (moveInput >= 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        anim.SetBool("IsRun", moveInput != 0);

        if (Input.GetKey(KeyCode.LeftShift))
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
            rb.AddForce(Vector2.up * jumpForce);

        anim.SetBool("IsJumping", !groundChecker.isGrounded);
    }


}