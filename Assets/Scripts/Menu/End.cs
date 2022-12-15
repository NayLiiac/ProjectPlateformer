using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string SceneName;
    [SerializeField] GameObject CPM = null;
    [SerializeField] Vector2 SpawnNextLevel;
    private void Start()
    {
        CPM = GameObject.FindWithTag("SpawnPoint");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        CPM.GetComponent<CheckpointManager>().Spawn = SpawnNextLevel;
        SceneManager.LoadScene(SceneName);
    }

       
    
}
