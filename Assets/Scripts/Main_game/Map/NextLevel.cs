using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    GameObject GC;
    void Start()
    {
        GC = GameObject.Find("GameController");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GC.GetComponent<GameManager>().NextLevel();
        }
    }
}
