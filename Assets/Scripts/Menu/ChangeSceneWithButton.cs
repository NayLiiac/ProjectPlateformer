using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneWithButton : MonoBehaviour
{
    public string SceneName;

    public void NextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
    private void Start()
    {
        if (gameObject.name == "PlayButton")
        {
            GetComponent<Button>().Select();
        }
        if (gameObject.name == "Lvl1Button")
        {
            GetComponent<Button>().Select();
        }
        if (gameObject.name == "BackButtonCredits")
        {
            GetComponent<Button>().Select();
        }
        if (gameObject.name == "BackButtonSettings")
        {
            GetComponent<Button>().Select();
        }
    }
}
