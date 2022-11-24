using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int MaxNumberOfDash = 1;
    public int DashForce = 1;
    public float DashTime=1f;
    public bool Dashing = false;
    public int DashCd = 3;
    Coroutine dashCooldown;
    public TextMeshProUGUI DashCount;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
        NumberOfJumps = MaxNumberOfJumps;
        NumberOfDash = MaxNumberOfDash;
        DashCount.text = ($"Dash : {NumberOfDash}"); 
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
        animator.SetBool("IsFalling", Rb.velocity.y < 0);

    }

    public void OnMove(InputValue moveValue)
    {
        Movement = moveValue.Get<Vector2>();
    }

    public void OnJump(InputValue JumpValue)
    {
        //animator.SetBool("IsJumping", true);
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
            DashCount.text = ($"Dash : {NumberOfDash}");
            StartCoroutine(wait());
        }
        if (dashCooldown== null)
        {
            dashCooldown = StartCoroutine(DashCooldown());
        }
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(DashTime);
        Rb.gravityScale = 1f;
        Dashing = false;
    }

    public IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(DashCd);
        NumberOfDash++;
        DashCount.text = ($"Dash : {NumberOfDash}");
        if (NumberOfDash < MaxNumberOfDash)
        {
            dashCooldown = StartCoroutine(DashCooldown());
        }
        else
        {
            dashCooldown = null;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y > 0.8f)
        {
            NumberOfJumps = MaxNumberOfJumps;

        }
    }
}