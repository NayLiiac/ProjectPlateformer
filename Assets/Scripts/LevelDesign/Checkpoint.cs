using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject spawnpoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && spawnpoint != null)
        {
            spawnpoint.transform.position = new Vector2(0, 45);
        }
    }
}
