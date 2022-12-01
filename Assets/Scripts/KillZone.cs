using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController Pc = other.GetComponent<PlayerController>();
        if (Pc != null)
        {
            Pc.Health-=1;
        }
    }
}
