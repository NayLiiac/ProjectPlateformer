using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpawnSpikes : MonoBehaviour
{
    public Animator animator = null;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsPlayerAround", collision.tag == "Player");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("IsPlayerAround", false);
        }
    }
}