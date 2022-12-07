using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform SpawnLocation;
    public GameObject Player;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController Pc = other.GetComponent<PlayerController>();
        DeathCount deathCount = other.GetComponent<DeathCount>();
        if (Pc != null)
        {
            Pc.Health-=1;
            deathCount.OnDeath();
            StartCoroutine(Pc.DeathWait());
        }
    }
}
