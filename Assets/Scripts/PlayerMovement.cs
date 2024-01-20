using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public int jumps;
    public Rigidbody2D rb;

    public Transform feetOrigin;
    public float feetOffset = 0.475f;
    public Vector2 colliderSize = new Vector2(1, 0.2f);
    public LayerMask groundLayer;

    private void Update()
    {
        if (OnGround())
        {
            jumps = 1;
        }

        if (Input.GetButton("Jump") && jumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

            jumps--;
        }
    }

    private void FixedUpdate()
    {
        float xVel = moveSpeed * Time.fixedDeltaTime;
        float yVel = rb.velocity.y;
        rb.velocity = new Vector2(xVel, yVel);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        jumps = 0;
    }

    bool OnGround()
    {
        return Physics2D.OverlapBox(feetOrigin.position + new Vector3(0, -feetOffset), colliderSize, 0, groundLayer);
    }
}
