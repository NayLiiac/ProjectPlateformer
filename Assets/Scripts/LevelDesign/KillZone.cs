using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        PlayerController Pc = other.GetComponent<PlayerController>();
        
        DeathCount deathCount = other.GetComponent<DeathCount>();
        
        Rigidbody2D Rb = other.GetComponent<Rigidbody2D>();

        CapsuleCollider2D PlayerCollider = other.GetComponent<CapsuleCollider2D>();
        BoxCollider2D PlayerBoxCollider = other.GetComponent<BoxCollider2D>();



        if (other.tag == "Player")
        {
            Rb.gravityScale = 0;
            Rb.velocity = Vector2.zero;

            PlayerCollider.enabled = false;
            PlayerBoxCollider.enabled = false;
            
            deathCount.OnDeath();
            Pc.Health -= 1;
            yield return StartCoroutine(Pc.DeathWait());
            
            Destroy(other.gameObject);
            Scene scene = SceneManager.GetActiveScene(); //by orvedal from unity's help room
            SceneManager.LoadScene(scene.name);
        }

    }
}