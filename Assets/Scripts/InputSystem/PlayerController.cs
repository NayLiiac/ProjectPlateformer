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



    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Rb == null)
        {
            return;
        }
        Rb.velocity = new Vector2(Movement.x * Speed , Rb.velocity.y);
    }

    public void OnMove(InputValue moveValue)
    {
        Movement = moveValue.Get<Vector2>();
    }
    public void OnJump(InputValue JumpValue)
    {
        float Pressed=JumpValue.Get<float>();
        Rb.velocity = new Vector2 (Rb.velocity.x , JumpForce);
        //Rb.AddForce(new Vector2(0, JumpForce ), ForceMode2D.Impulse);
    }
}
