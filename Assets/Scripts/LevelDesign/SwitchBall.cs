using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBall : MonoBehaviour
{
    Rigidbody2D Rb;
    Collider2D Cl;
    public GameObject Circle;
    public GameObject Parent;
    private void Start()
    {
        Cl = GetComponent<Collider2D>();
        Rb = Circle.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            Rb.gravityScale = 1;
            Destroy(Circle,10f);
            Destroy(gameObject);
        }
       if (Parent != null)
        {
            Destroy(Parent,10f);
        } 
    }
}
