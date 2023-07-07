using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;

    Vector2 moveInput;
    Rigidbody2D rb;
    Animator myAnimator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;


   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator= GetComponent<Animator>();
        bodyCollider= GetComponent<CapsuleCollider2D>();
        feetCollider= GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        Run();
        FlipSprite();

        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("isRunning ", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="EnemyHead")
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }

}
