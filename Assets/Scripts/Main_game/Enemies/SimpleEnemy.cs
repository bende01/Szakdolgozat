using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;

    public void GetDamage(float dmg)
    {
        health -= dmg;
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
