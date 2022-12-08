using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        PlayerController Pc = other.GetComponent<PlayerController>();
        DeathCount deathCount = other.GetComponent<DeathCount>();
        CapsuleCollider2D PlayerCollider = other.GetComponent<CapsuleCollider2D>();
        BoxCollider2D PlayerBoxCollider = other.GetComponent<BoxCollider2D>();
        Rigidbody2D Rb = other.GetComponent<Rigidbody2D>();

        if (Pc != null)
        {
            Rb.gravityScale = 0;
            Rb.velocity = Vector2.zero;
            PlayerCollider.enabled = false;
            PlayerBoxCollider.enabled = false;    
            Pc.Health -= 1;
            deathCount.OnDeath();
            yield return StartCoroutine(Pc.DeathWait());
            PlayerCollider.enabled = true;
            PlayerBoxCollider.enabled = true;
            Rb.gravityScale = 1;
        }
    }
}
