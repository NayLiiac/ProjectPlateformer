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
        Deathcount.text = NumberOfDeaths.ToString();
    }


    public void OnDeath()
    {
        PlayerController Pc = GetComponent<PlayerController>();
        if (Pc.Health == 0)
        {
            NumberOfDeaths++;
            
        }
        Deathcount.text = NumberOfDeaths.ToString();
    }
   
}
