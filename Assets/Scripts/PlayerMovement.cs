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
    private bool isGameStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("startRunning");
    }

    void Update()
    {
        if(!isGameStarted){
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                isGameStarted= true;
                return;
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                jumpPressed = true;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            jumpPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

        if (moveSpeed <= 0)
        {
            animator.SetTrigger("stopRunning");
        }

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (jumpPressed && isGrounded)
        {
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

