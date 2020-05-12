using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameController").GetComponent<GameManager>();
    }
    // Update is called once per frame
    public void Winner()
    {
        gm.EndGame(true);
    }
}
