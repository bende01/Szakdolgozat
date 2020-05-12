using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    public Animator anim;


    private Boss_Behaviour boss;
    public bool invulnerable = false;

    private void Start()
    {
        if (GameObject.Find("Boss") != null) {
            boss = GameObject.Find("Boss").GetComponent<Boss_Behaviour>();
        }
        
    }
    public void GetDamage(float dmg)
    {
        if (!invulnerable)
        {
            anim.SetTrigger("hit");
            if (boss != null)
            {
                boss.GetDamage(dmg);
            }
            else
            {
                health -= dmg;
                Debug.Log(health);

            }
        }
       
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if(health <= 0)
        {
            anim.SetTrigger("dead");
            Destroy(gameObject,1f);
        }
    }
}
