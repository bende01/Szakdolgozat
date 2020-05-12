using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public Text wins;
    public Text deaths;

    // Update is called once per frame
    private void Start()
    {
        wins.text += PlayerPrefs.GetInt("wins", 0).ToString();
        deaths.text += PlayerPrefs.GetInt("deaths", 0).ToString();
    }
}
