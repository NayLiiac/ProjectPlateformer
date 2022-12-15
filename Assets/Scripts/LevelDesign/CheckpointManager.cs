using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    //bool StartLVL = false;
    public Vector2 Spawn;
    public bool StartLVL = false;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
