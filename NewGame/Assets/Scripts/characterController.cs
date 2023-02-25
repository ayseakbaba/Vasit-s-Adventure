using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 250f;
    private Rigidbody2D r2d;
    private Animator anim;
    
    private bool grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        r2d = GetComponent<Rigidbody2D>();  //caching
        anim = GetComponent<Animator>();    //caching
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (started && grounded)
            {
                anim.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                anim.SetBool("GameStarted", true);
                started = true;
            }
        }
        anim.SetBool("Grounded", grounded);
        }

    private void FixedUpdate() //karakterin fiziki işlemleri için kullanılır.
    {
        if (started)
        {
            r2d.velocity = new Vector2(speed, r2d.velocity.y);
        }

        if (jumping)
        {
            r2d.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
