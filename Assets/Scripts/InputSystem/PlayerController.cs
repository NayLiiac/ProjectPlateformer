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
    public int DashForce = 1;
    public float DashTime=1f;
    public bool Dashing = false;



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
        
        if (!Dashing)
        {
            Rb.velocity = new Vector2(Movement.x * Speed, Rb.velocity.y);
        }


        animator.SetBool("IsRunning", Rb.velocity.x != 0);
        if (Movement.x != 0)
        {
            Renderer.flipX = Movement.x < 0;
        }
        animator.SetBool("IsIdle", Rb.velocity == Vector2.zero);

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

    void OnDash()
    {
        if (NumberOfDash > 0 && Rb.velocity.x != 0)
        {
            Dashing = true;
            Rb.gravityScale = 0f;
            if (Movement.x > 0)
            {
                Rb.velocity = new Vector2(DashForce, 0);
            }
            else
            {
                Rb.velocity = new Vector2(-DashForce , 0);

            }
            NumberOfDash--;
            StartCoroutine(wait());
        }
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(DashTime);
        Rb.gravityScale = 1f;
        Dashing = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y > 0.8f)
        {
            NumberOfJumps = MaxNumberOfJumps;
            NumberOfDash = 1;

        }
    }
}
