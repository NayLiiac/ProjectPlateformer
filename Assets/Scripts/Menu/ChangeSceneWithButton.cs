using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    public string SceneName;

    public void NextScene()
    {
        SceneManager.LoadScene(SceneName);
        if (SceneName=="Menu") Cursor.visible = true;
    }
}
