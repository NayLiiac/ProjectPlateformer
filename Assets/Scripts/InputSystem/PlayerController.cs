using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Vector2 Movement = Vector2.zero;
    Rigidbody2D Rb = null;
    Animator animator = null;
    SpriteRenderer Renderer = null;
    public float Speed = 1;
    public float JumpForce = 1;
    public int NumberOfJumps = 0;
    public int MaxNumberOfJumps = 2;
    public int NumberOfDash = 0;
    public int DashForce = 0;



    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
        NumberOfJumps = MaxNumberOfJumps;
    }

    void Update()
    {

        if (Rb == null)
        {
            return;
        }
        Rb.velocity = new Vector2(Movement.x * Speed, Rb.velocity.y);

        animator.SetBool("IsRunning", Rb.velocity.x != 0);
        if (Movement.x != 0)
        {
            Renderer.flipX = Movement.x < 0;
        }
        animator.SetBool("IsFalling", Rb.velocity.y < 0);
        animator.SetBool("IsIdle", Rb.velocity == Vector2.zero);
        animator.SetBool("IsJumping", Input.GetButton("Jump"));

    }

    public void OnMove(InputValue moveValue)
    {
        Movement = moveValue.Get<Vector2>();
    }
    public void OnJump(InputValue JumpValue)
    {
        if (NumberOfJumps > 0)
        {
            float Pressed = JumpValue.Get<float>();
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);
            NumberOfJumps--;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y > 0.8f)
        {
            NumberOfJumps = MaxNumberOfJumps;
        }

        if (collision.GetContact(0).normal.y > 0.8f)
        {
            NumberOfDash = 1;
        }
    }
}
