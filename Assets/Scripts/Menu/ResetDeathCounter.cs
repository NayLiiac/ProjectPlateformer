using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDeathCounter : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log(PlayerPrefs.GetInt("DeathCounter"));
        PlayerPrefs.DeleteKey("DeathCounter");
        PlayerPrefs.SetInt("DeathCounter",0);
        Debug.Log(PlayerPrefs.GetInt("DeathCounter"));

    }
}
