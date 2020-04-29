using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().InstantDeath();
        }
    }
}
