using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //Move and Animator Variables 
    Vector2 Movement = Vector2.zero;
    Rigidbody2D Rb = null;
    Animator animator = null;
    SpriteRenderer Renderer = null;

    public float Speed = 1;

    //Jumps Variables
    public float JumpForce = 1;
    public int NumberOfJumps = 0;
    public int MaxNumberOfJumps = 2;

    //Dashs Variables
    public int NumberOfDash = 0;
    public int MaxNumberOfDash = 1;
    public int DashForce = 1;
    public float DashTime = 1f;
    public bool Dashing = false;
    public int DashCd = 3;
    Coroutine dashCooldown;
    public TextMeshProUGUI DashCount;

    //Health and Die Variables
    public int Health = 1;
    public bool DieOneTimeOnlyPlease = false;
    public Transform SpawnLocation = null;



    void Start()
    {
        //Sets the cursor invisible
        Cursor.visible = false;

        //Gets components of the player
        Rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();

        //Initialises Dashs and Jumps
        NumberOfJumps = MaxNumberOfJumps;
        NumberOfDash = MaxNumberOfDash;
        DashCount.text = NumberOfDash.ToString();
    }



    void Update()
    {
        // Checks if the rigidbody just exist or not
        if (Rb == null)
        {
            return;
        }

        //Checks if the player isn't dashing and allow it to move
        if (!Dashing)
        {
            Rb.velocity = new Vector2(Movement.x * Speed, Rb.velocity.y);
        }

        //Flips the player's sprite if it goes backward
        if (Movement.x != 0)
        {
            Renderer.flipX = Movement.x < 0;
        }

        //Animator's Boolean
        if (Health > 0)
        {
            animator.SetBool("IsRunning", Rb.velocity.x != 0 && Rb.velocity.y == 0 && Dashing == false);
            animator.SetBool("IsIdle", Rb.velocity == Vector2.zero);
            animator.SetBool("IsFalling", Rb.velocity.y < 0);
        }

        //Checks the player's Health and sets the cursor visible 
        if (Health <= 0 && !DieOneTimeOnlyPlease)
        {
            DieOneTimeOnlyPlease = true;
            animator.Play("Die");

            Cursor.visible = true;
            GetComponent<PlayerInput>().enabled = false;
        }
    }



    //Sets the player's movements
    public void OnMove(InputValue moveValue)
    {
        Movement = moveValue.Get<Vector2>();
    }



    //Allows the player to Jump or Double Jump depending on its position while is still has jump(s) to use
    public void OnJump()
    {
        if (Rb.velocity.y == 0 && NumberOfJumps > 0)
        {
            animator.SetBool("IsJumping", true);
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);
            NumberOfJumps--;
            StartCoroutine(JumpWait());
        }

        else if (Rb.velocity.y != 0 && NumberOfJumps > 0)
        {
            animator.SetBool("DoubleJump", true);
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);
            NumberOfJumps--;
            StartCoroutine(DoubleJumpWait());
        }

    }



    //Sets the timing of the Jump animation
    public IEnumerator JumpWait()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("IsJumping", false);
    }

    //Sets the timing of the Double Jump animation
    public IEnumerator DoubleJumpWait()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("DoubleJump", false);
    }

    // Sets the timing of the Death animation
    public IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(3f);
        Health = 1;

        Cursor.visible = false;
        GetComponent<PlayerInput>().enabled = true;
        transform.position = SpawnLocation.position;
        if (transform.position == SpawnLocation.position)
        {
            animator.SetBool("IsDead", false);
        }
        DieOneTimeOnlyPlease = false;

    }



    //Allows the player to Dash while it has dash(s) to use and Write the numbers of dashs left to use in a UIText
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
                Rb.velocity = new Vector2(-DashForce, 0);
            }
            NumberOfDash--;
            DashCount.text = NumberOfDash.ToString();
            animator.SetBool("IsDashing", true);
            StartCoroutine(Wait());
        }
        if (dashCooldown == null && Rb.velocity.x != 0)
        {
            dashCooldown = StartCoroutine(DashCooldown());
        }
    }



    //Waits for the dash time and modifies the GravityScale
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(DashTime);
        animator.SetBool("IsDashing", false);
        Rb.gravityScale = 1f;
        Dashing = false;
    }



    //Sets a cooldown for using dashs
    public IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(DashCd);
        NumberOfDash++;
        DashCount.text = NumberOfDash.ToString();
        if (NumberOfDash < MaxNumberOfDash)
        {
            dashCooldown = StartCoroutine(DashCooldown());
        }
        else
        {
            dashCooldown = null;
        }
    }



    // Resets the jump count to maximum when the bottom collider is triggered by a wall
    private void OnTriggerEnter2D(Collider2D collision) //By Audran 
    {
        if (collision.tag == "Wall")
        {
            NumberOfJumps = MaxNumberOfJumps;
        }
    }
}