using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIndicator : MonoBehaviour
{
    public TextMeshProUGUI LevelIndic;
    public string Level;

    void Start()
    {
        Level = SceneManager.GetActiveScene().name;
        LevelIndic.text = Level;
    }
}
