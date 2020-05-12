using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Behaviour : MonoBehaviour
{
    GameManager gm;
    private Animation win;

    public float health = 1000f;
    public GameObject player;
    public Animator anim;
    public GameObject bowman;
    public GameObject jumpy;
    public GameObject dasher;
    public GameObject tank;
    public GameObject skeleton;
    public GameObject mage;


    public float meleeRange;

    private bool phase2 = false;
    private bool dead = false;
    private float distance;
    public float currentHealth;

    private void Start()
    {
        win = GameObject.Find("WinPanel").GetComponent<Animation>();
        currentHealth = health;
    }
    void Update()
    {

        Die();
    }

    private void Die()
    {
        if (currentHealth <=0 && !dead)
        {
            dead = true;


            

            bowman.GetComponentInChildren<Animator>().SetTrigger("dead");
            jumpy.GetComponentInChildren<Animator>().SetTrigger("dead");
            dasher.GetComponentInChildren<Animator>().SetTrigger("dead");
            tank.GetComponentInChildren<Animator>().SetTrigger("dead");
            skeleton.GetComponentInChildren<Animator>().SetTrigger("dead");
            mage.GetComponentInChildren<Animator>().SetTrigger("dead");

            Destroy(gameObject);
            Destroy(bowman, 1f);
            Destroy(jumpy, 1f);
            Destroy(dasher, 1f);
            Destroy(tank, 1f);
            Destroy(skeleton, 1f);
            Destroy(mage, 1f);

            win.Play();
        }
    }

    private void Phase2()
    {
        if (currentHealth < health / 2)
        {
            phase2 = true;
            anim.SetTrigger("phase2");
            bowman.SetActive(false);
            jumpy.SetActive(false);
            dasher.SetActive(false);
        }
    }

    public void Knocback()
    {

        anim.SetTrigger("knocked");
        //anim.ResetTrigger("knocked");
    }

    public void KnockMissed()
    {
        anim.SetTrigger("knockMissed");
       // anim.ResetTrigger("knockMissed");
    }
    public void GetDamage(float dmg)
    {
        currentHealth -= dmg;

        if (!phase2)
        {
            Phase2();
        }
    }


}
