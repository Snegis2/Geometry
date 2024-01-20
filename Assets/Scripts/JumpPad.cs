using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 7;
    public float cooldown = 1;
    private bool active = true;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && active)
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            active = false;
            Invoke("Activate", cooldown);
        }
    }

    void Activate()
    {
        active = true;
    }
}
