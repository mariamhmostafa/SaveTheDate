using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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

