using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpy_damage : MonoBehaviour
{
    // Start is called before the first frame update
    public float attack1Damage = 20;
    public float attack2Damage = 10;
    public float attack3Damage = 50;

    public int sequence;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (sequence)
            {
                case 1: 
                    collision.GetComponent<Player>().GetDamage(attack1Damage);
                    break;
                case 2: 
                    collision.GetComponent<Player>().GetDamage(attack2Damage);
                    break;
                case 3:
                    collision.GetComponent<Player>().GetDamage(attack3Damage);
                    break;
            }
           
        }

    }

    

}
