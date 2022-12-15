using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    //bool StartLVL = false;
    public Vector2 Spawn;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SpawnPoint").Length>1)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
