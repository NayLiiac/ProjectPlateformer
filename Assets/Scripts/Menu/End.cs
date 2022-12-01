using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string SceneName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneName);
    }
}
