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
        StartCoroutine(SwitchAgain());
    }
    private IEnumerator SwitchAgain()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsPlayerAround", false);
    }
}
