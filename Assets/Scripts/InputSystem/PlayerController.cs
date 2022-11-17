using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Vector2 Movement = Vector2.zero;
    Rigidbody2D Rb = null;
    public float Speed = 1;
    public float JumpForce = 1;
    public int NumberOfJumps = 0;
    public int MaxNumberOfJumps = 2;
    public int NumberOfDash = 0;
    public int DashForce = 1;
    //public int MaxNumberOfDash=1



    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        NumberOfJumps = MaxNumberOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Rb == null)
        {
            return;
        }
        Rb.velocity = new Vector2(Rb.velocity.x + Movement.x * Speed , Rb.velocity.y);
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

    public void OnDash()
    {
        Debug.Log("ihidsiqhuv");
        if (NumberOfDash > 0)
        {
            Rb.velocity = new Vector2(DashForce, Rb.velocity.y);
            NumberOfDash--;
        }
        
    }
}
