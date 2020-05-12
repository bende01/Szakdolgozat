using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_enemy_behind : MonoBehaviour
{
    // Start is called before the first frame update
    SimpleEnemy tank;

    private void Start()
    {
        tank = gameObject.GetComponentInParent<SimpleEnemy>();
        tank.invulnerable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    
        if (collision.tag == "Player")
        {
            tank.invulnerable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tank.invulnerable = true;
        }
    }
}
