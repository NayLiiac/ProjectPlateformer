using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    // Variable in order to count the number of deaths :

    public TextMeshProUGUI Deathcount;
    public int NumberOfDeaths = 0;

    // Initializes number of deaths :
    void Start()
    {
        NumberOfDeaths = PlayerPrefs.GetInt("DeathCounter");
        Deathcount.text = PlayerPrefs.GetInt("DeathCounter").ToString();
    }


    public void OnDeath()
    {
        NumberOfDeaths++;
        PlayerPrefs.SetInt("DeathCounter", NumberOfDeaths);
        NumberOfDeaths = PlayerPrefs.GetInt("DeathCounter");

        Deathcount.text = NumberOfDeaths.ToString();
    }

}
