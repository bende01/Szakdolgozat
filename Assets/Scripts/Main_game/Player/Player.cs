using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation death;


    public float health;
    public float maxHealth = 100f;
    
    public string[] weapons;

    public Animator anim;

    int i = 0;

    public bool invulnerable = false;

    private void Update()
    {
   //     CicleWeapons();

        Die();
    }
    private void Start()
    {
       death = GameObject.Find("DeathPanel").GetComponent<Animation>();
        health = PlayerPrefs.GetFloat("health", maxHealth);
    }
    private void CicleWeapons()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            if (i + 1 < weapons.Length)
            {
                i++;
                SwitchWeapon(weapons[i]);
            }
            else
            {
                i = 0;
                SwitchWeapon(weapons[i]);
            }
        }
    }

    private void SwitchWeapon(string wep)
    {
        switch (wep)
        {
            case "Bullet":
                GetComponent<Weapon>().enabled = true;
                GetComponent<LaserWeapon>().enabled = false;
                break;
            case "Laser":
                GetComponent<LaserWeapon>().enabled = true;
                GetComponent<Weapon>().enabled = false;
                break;
        }
    }

    private void Die()
    {
        if (health <= 0)
        {
            anim.Play("Player_dead");
            Destroy(gameObject,1f);
            Deathanimation();
        }
    }

    public void InstantDeath()
    {
        Deathanimation();
        health = 0;
        Destroy(gameObject);
    }




    public void GetDamage(float dmg)
    {
        if (invulnerable)
        {
            return;
        }
        health -= dmg;
        anim.SetTrigger("getHit");
        PlayerPrefs.SetFloat("health", health);
    }

    void Deathanimation()
    {
            death.Play();
    }

}
