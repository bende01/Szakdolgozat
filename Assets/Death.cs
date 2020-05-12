using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameManager gm;


    private void Start()
    {
        gm = GameObject.Find("GameController").GetComponent<GameManager>();
    }
    public void Died()
    {
        gm.EndGame(false);
    }
}
