using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject CPM = null;
    BoxCollider2D Coll = null;
    private void Start()
    {
        CPM = GameObject.FindWithTag("SpawnPoint");
        Coll = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CPM.GetComponent<CheckpointManager>().Spawn = gameObject.transform.position;
        }
    }
}