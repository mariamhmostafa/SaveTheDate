using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private bool jumpPressed = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("startRunning");
    }

    void Update()
    {

        // Handle mouse or touch input
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Jump Pressed");
            jumpPressed = true;
        }
        if(moveSpeed>0){
            // set animator trigger to run
            // animator.SetTrigger("startRunning");
        }else{
            animator.SetTrigger("stopRunning");
        }
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Debug.Log($"MoveSpeed: {moveSpeed}, IsGrounded: {isGrounded}");

        if (jumpPressed && isGrounded)
        {
            Debug.Log("Jump Pressed");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            jumpPressed = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.contacts[0].normal.y > 0.5f)
            isGrounded = true;

        if (other.gameObject.CompareTag("FinishLine"))
        {
            moveSpeed = 0;
        }
        if (other.gameObject.CompareTag("Ground") ||
            other.gameObject.CompareTag("StartLine") ||
            other.gameObject.CompareTag("FinishLine"))
        {
            isGrounded = true;
        }


    }

}

