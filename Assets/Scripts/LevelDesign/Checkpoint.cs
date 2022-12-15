using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameObject CPM = null;
    private void Start()
    {
    CPM = GameObject.FindWithTag("SpawnPoint");
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CPM.GetComponent<CheckpointManager>().Spawn = gameObject.transform.position;
        }
    }
}
