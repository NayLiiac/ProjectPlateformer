using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneWithButton : MonoBehaviour
{
    public string SceneName;

    [SerializeField] GameObject CPM = null;
    public Dictionary<string, Vector2> SpawnLocationsForLVls= new()
    {
        {"Level 1",new Vector2(-8,-5) },
        {"Level 2",new Vector2(18,37) },
        {"Level 3",new Vector2(-111.5f,48) },
        {"Level 4",new Vector2(15,27) },
        {"Level 5",new Vector2(-123,-26) },
        {"Level 6",new Vector2(-106.5f,-8) },
        {"Level 7",new Vector2(16,-8) },
        {"Level 8",new Vector2(-84,-70) },

    };
    public void NextScene()
    {
        if (CPM != null)
        {
            if (SpawnLocationsForLVls.ContainsKey(SceneName))
            {
                CPM.GetComponent<CheckpointManager>().Spawn = SpawnLocationsForLVls[SceneName];
                SceneManager.LoadScene(SceneName);
            }
            else
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }
    private void Start()
    {
        CPM = GameObject.FindWithTag("SpawnPoint");

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
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            
        }
    }
}
