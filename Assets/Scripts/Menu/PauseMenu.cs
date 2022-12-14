using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuObject = null;
    [SerializeField] GameObject player = null;
    [SerializeField] Button DefaultButtonSelected = null;
    void OnPause()
    {
        PlayerController Pc = gameObject.GetComponent<PlayerController>();

        if (Pc.Health > 0 && PauseMenuObject != null)
        {
            
            if (Time.timeScale == 1)
            {
                gameObject.GetComponent<PlayerController>().enabled = false;
                Time.timeScale = 0f;
                PauseMenuObject.SetActive(true);
                DefaultButtonSelected.Select();
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
                Time.timeScale = 1f;
                gameObject.GetComponent<PlayerController>().enabled = true;
                PauseMenuObject.SetActive(false);
            }
        }

    }
    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        player.GetComponent<PlayerController>().enabled = true;
        PauseMenuObject.SetActive(false);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }
}
