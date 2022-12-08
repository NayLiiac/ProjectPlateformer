using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseFlip : MonoBehaviour
{
    public int SpeedReturn = 0;
    Rigidbody2D Rb = null;

    public SpriteRenderer Sr = null;
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        Rb.velocity = new Vector2(0, SpeedReturn);
    }

    private void Update()
    {
        Sr.flipY = Rb.velocity.y > 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Lava")
        {
            Rb.velocity = new Vector2(0, SpeedReturn);
        }
    }
}
